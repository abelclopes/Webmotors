using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmotors.Application.Anuncios.Notification
{
    public class AnuncioAlteradaNotification : INotification
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
