using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmotors.Domain.Repository.Abstractions;

namespace Webmotors.Application.Anuncios.Query
{
    public class ObterTodosAnunciosQueryHandler : IRequestHandler<ObterTodosAnunciosQuery, IList<ObterAnunciosViewModel>>
    {
        private readonly IAnunciosRepository _anunciosRepository;
        private readonly IMapper mapper;

        public ObterTodosAnunciosQueryHandler(IAnunciosRepository anunciosRepository, IMapper mapper)
        {
            this._anunciosRepository = anunciosRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ObterAnunciosViewModel>> Handle(ObterTodosAnunciosQuery request, CancellationToken cancellationToken)
        {
            var anuncios = await _anunciosRepository.ObterAnuncios();
            var anuncioViewModel = mapper.Map<IEnumerable<ObterAnunciosViewModel>>(anuncios);

            return anuncioViewModel.ToList();
        }
    }
}
