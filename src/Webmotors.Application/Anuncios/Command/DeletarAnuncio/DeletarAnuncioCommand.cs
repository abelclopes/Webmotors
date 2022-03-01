using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application.Anuncios.Command.DeletarAnuncio
{
    public class DeletarAnuncioCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
