using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Domain;

namespace Webmotors.Domain.Repository.Abstractions
{
    public interface IAnunciosRepository
    {
        Task<bool> Registrar(Anuncio anuncio);
        Task<IEnumerable<Anuncio>> ObterAnuncios();
    }
}
