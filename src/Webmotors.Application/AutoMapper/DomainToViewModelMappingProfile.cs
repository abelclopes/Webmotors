using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Query;
using Webmotors.Domain;

namespace Webmotors.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Anuncio, ObterAnuncioViewModel>().ReverseMap();
            CreateMap<ObterAnuncioViewModel, Anuncio > ().ReverseMap();            
        }
    }
}
