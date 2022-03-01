using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Notification;
using Webmotors.Domain;
using Webmotors.Domain.Repository.Abstractions;

namespace Webmotors.Application.Anuncios.Command.Cadastrar
{
    public class CadastraAnuncioCommandHandler : IRequestHandler<CadastraAnuncioCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IAnunciosRepository _repository;
        public CadastraAnuncioCommandHandler(IMediator mediator, IAnunciosRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraAnuncioCommand request, CancellationToken cancellationToken)
        {
            var anuncio = new Anuncio(request.Marca, request.Modelo, request.Ano, request.Versao, request.Quilometragem, request.Observacao);

            try
            {
                anuncio = await _repository.Create(anuncio);

                await _mediator.Publish(new AnuncioCriadoNotification {Id = anuncio.Id, Marca = anuncio.Marca, Modelo= anuncio.Modelo, Ano=anuncio.Ano , Versao= anuncio.Versao , Quilometragem = anuncio.Quilometragem , Observacao = anuncio.Observacao});

                return await Task.FromResult("Anuncio criado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new AnuncioCriadoNotification { Id = anuncio.Id, Marca = anuncio.Marca, Modelo = anuncio.Modelo, Ano = anuncio.Ano, Versao = anuncio.Versao, Quilometragem = anuncio.Quilometragem, Observacao = anuncio.Observacao });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }
}
