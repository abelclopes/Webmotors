using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Notification;

namespace Webmotors.Application.Anuncios
{
    public class LogEventHandler :
                            INotificationHandler<AnuncioCriadoNotification>,
                            INotificationHandler<AnuncioAlteradaNotification>,
                            INotificationHandler<AnuncioExcluidoNotification>,
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(AnuncioCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Marca} - {notification.Modelo} - {notification.Ano} - {notification.Versao}- {notification.Quilometragem} - {notification.Observacao}'");
            });
        }

        public Task Handle(AnuncioAlteradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Marca} - {notification.Modelo} - {notification.Ano} - {notification.Versao}- {notification.Quilometragem} - {notification.Observacao}'");
            });
        }

        public Task Handle(AnuncioExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }
    }
}
