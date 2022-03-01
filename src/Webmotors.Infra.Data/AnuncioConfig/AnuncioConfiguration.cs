using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webmotors.Domain;
//using Microsoft.EntityFrameworkCore.Relational;

namespace Webmotors.infra.AnuncioConfig
{
    public class AnuncioConfiguration : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {

            builder.ToTable("tb_AnuncioWebmotors");

            builder.Property(e => e.Ano).HasColumnName("ano");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Marca)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marca");

            builder.Property(e => e.Modelo)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("modelo");

            builder.Property(e => e.Observacao)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("observacao");

            builder.Property(e => e.Quilometragem).HasColumnName("quilometragem");

            builder.Property(e => e.Versao)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("versao");

        }
    }
}
