using System;
using MediatR;

namespace Webmotors.Application.Anuncios.Command.RegistrarAnuncio
{
    public class RegistrarAnuncioCommand : IRequest<bool>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
