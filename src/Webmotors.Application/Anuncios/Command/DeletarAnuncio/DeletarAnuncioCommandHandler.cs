using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Notification;
using Webmotors.Domain.Repository.Abstractions;

namespace Webmotors.Application.Anuncios.Command.DeletarAnuncio
{
    public class DeletarAnuncioCommandHandler : IRequestHandler<DeletarAnuncioCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IAnunciosRepository _repository;
        public DeletarAnuncioCommandHandler(IMediator mediator, IAnunciosRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeletarAnuncioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new AnuncioExcluidoNotification { Id = request.Id});

                return await Task.FromResult("Anuncio excluído com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new AnuncioExcluidoNotification { Id = request.Id });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }

        }
    }
}

