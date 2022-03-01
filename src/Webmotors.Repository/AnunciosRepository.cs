using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Domain;
using Webmotors.Domain.Interfaces;
using Webmotors.Domain.Repository.Abstractions;

namespace Webmotors.Domain.Repository
{
    public class AnunciosRepository : IAnunciosRepository
    {
        private readonly IContext _context;

        public AnunciosRepository(ILogger<AnunciosRepository> looger, IContext context)
        {
            _context = context;
        }

      
        public async Task<bool> Registrar(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            if(await _context.SaveChangesAsync() == 1) return true;
            return false;
        }

        public async Task<IEnumerable<Anuncio>> ObterAnuncios() =>  await Task.FromResult(_context.Anuncios);
    }
}
