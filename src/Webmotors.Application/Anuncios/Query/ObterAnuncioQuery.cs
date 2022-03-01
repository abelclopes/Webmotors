using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application.Anuncios.Query
{
    public class ObterAnuncioQuery : IRequest<ObterAnuncioViewModel>
    {
        public int Id { get; set; }
    }
}
