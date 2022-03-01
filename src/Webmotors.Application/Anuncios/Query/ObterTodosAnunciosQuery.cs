﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application.Anuncios.Query
{
    public class ObterTodosAnunciosQuery : IRequest<IList<ObterAnuncioViewModel>>
    {
        public int Id { get; set; }

    }
}
