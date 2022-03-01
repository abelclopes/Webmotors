using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Webmotors.Domain;
using Webmotors.Domain.Interfaces;
using Webmotors.Domain.Repository.Abstractions;
using Webmotors.infra.data.UoW;

namespace Webmotors.Application.Anuncios.Command.RegistrarAnuncio
{
    public class RegistrarAnuncioCommandHandler : CommandHandler, IRequestHandler<RegistrarAnuncioCommand, bool>
    {
        private readonly IAnunciosRepository _anuncioRepository;

        public RegistrarAnuncioCommandHandler(IAnunciosRepository anuncioRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _anuncioRepository = anuncioRepository;
        }
        public async Task<bool> Handle(RegistrarAnuncioCommand request, CancellationToken cancellationToken)
        {
            var anuncio = new Anuncio(request.Marca, request.Modelo, request.Versao, request.Ano, request.Quilometragem, request.Observacao);
            await _anuncioRepository.Registrar(anuncio);

            var commit  = Commit();
            PublishEvents(anuncio.Events);
            
            return commit;
        }

    }
}
