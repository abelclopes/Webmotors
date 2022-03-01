using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application.Anuncios.Command.AtualizarAnuncio
{
    public class AtualizarAnuncioCommand : IRequest<string>
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
