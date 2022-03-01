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
    public class ObterAnuncioQueryHandler : IRequestHandler<ObterAnuncioQuery, ObterAnuncioViewModel>
    {
        private readonly IAnunciosRepository _anunciosRepository;
        private readonly IMapper mapper;

        public ObterAnuncioQueryHandler(IAnunciosRepository anunciosRepository, IMapper mapper)
        {
            this._anunciosRepository = anunciosRepository;
            this.mapper = mapper;
        }

        public async Task<ObterAnuncioViewModel> Handle(ObterTodosAnunciosQuery request, CancellationToken cancellationToken)
        {
            var anuncios = await _anunciosRepository.ObterAnuncioById(request.Id);
            var anuncioViewModel = mapper.Map<ObterAnuncioViewModel>(anuncios);

            return anuncioViewModel;
        }

        public async Task<ObterAnuncioViewModel> Handle(ObterAnuncioQuery request, CancellationToken cancellationToken)
        {
            var anuncios = await _anunciosRepository.ObterAnuncioById(request.Id);
            var anuncioViewModel =  mapper.Map<ObterAnuncioViewModel>(anuncios);

            return anuncioViewModel;
        }
    }
}
