using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Domain.Interfaces
{
    public interface IContext 
    {
        DbSet<Anuncio> Anuncios { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
