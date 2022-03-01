using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Notification;
using Webmotors.Domain;
using Webmotors.Domain.Repository;
using Webmotors.Domain.Repository.Abstractions;
using Webmotors.Infra.Data.UoW;

namespace Webmotors.Application.Anuncios.Command.AtualizarAnuncio
{
    public class AtualizarAnuncioCommandHandler :  IRequestHandler<AtualizarAnuncioCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IAnunciosRepository _repository;
    public AtualizarAnuncioCommandHandler(IMediator mediator, IAnunciosRepository repository)
    {
        this._mediator = mediator;
        this._repository = repository;
    }

    public async Task<string> Handle(AtualizarAnuncioCommand request, CancellationToken cancellationToken)
    {
            Anuncio anuncioForUpdate = new Anuncio(request.Marca, request.Modelo, request.Ano, request.Versao, request.Quilometragem, request.Observacao);
            anuncioForUpdate.Id = request.Id;

        try
        {
            await _repository.Atualizar(anuncioForUpdate);

            await _mediator.Publish(new AnuncioAlteradaNotification
            {
                Id = request.Id,
                Marca = request.Marca,
                Modelo = request.Modelo,
                Ano = request.Ano,
                Versao = request.Versao,
                Quilometragem = request.Quilometragem,
                Observacao = request.Observacao
            });

            return await Task.FromResult("Anuncio alterado com sucesso");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new AnuncioAlteradaNotification { Id = anuncioForUpdate.Id, Modelo = request.Modelo, Ano = request.Ano, Versao = request.Versao, Quilometragem = request.Quilometragem, Observacao = request.Observacao });
            await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            return await Task.FromResult("Ocorreu um erro no momento da alteração");
        }

    }
}
}
