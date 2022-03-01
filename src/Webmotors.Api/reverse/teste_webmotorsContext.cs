using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Webmotors.Api.reverse
{
    public partial class teste_webmotorsContext : DbContext
    {
        public teste_webmotorsContext()
        {
        }

        public teste_webmotorsContext(DbContextOptions<teste_webmotorsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAnuncioWebmotor> TbAnuncioWebmotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,11433;Database=teste_webmotors;User ID=sa;Password=Testing1122;Trusted_Connection=False; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAnuncioWebmotor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tb_AnuncioWebmotors");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("observacao");

                entity.Property(e => e.Quilometragem).HasColumnName("quilometragem");

                entity.Property(e => e.Versao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("versao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
