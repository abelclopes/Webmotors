using System;
using Webmotors.Domain;
using Webmotors.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Webmotors.infra.AnuncioConfig;
using System.Threading.Tasks;

namespace Webmotors.infra
{
    public class WebmotorsAnunciosContext : DbContext, IContext
    {
        public WebmotorsAnunciosContext(DbContextOptions options) : base(options) { }

        public DbSet<Anuncio> Anuncios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Event>();
            
            modelBuilder.ApplyConfiguration(new AnuncioConfiguration());

        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
