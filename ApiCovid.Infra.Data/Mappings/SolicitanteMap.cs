using ApiCovid.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCovid.Infra.Data.Mappings
{
    public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.HasKey(s => s.IdSolicitante);

            //mapeamento das propriedades
            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.Perfil)
                .IsRequired()
                .HasMaxLength(2);

            //para ignorar o campo
            builder.Ignore(u => u.AccessToken);

            //para não se repetirem
            builder.HasIndex(s => s.Nome).IsUnique();
            builder.HasIndex(s => s.CPF).IsUnique();

        }
    }
}
