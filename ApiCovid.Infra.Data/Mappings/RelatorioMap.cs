using ApiCovid.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Infra.Data.Mappings
{
    public class RelatorioMap : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.HasKey(r => r.IdRelatorio);

            builder.Property(r => r.QtdeVacinados).IsRequired();
            builder.Property(r=>r.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(r=>r.Fabricante).IsRequired().HasMaxLength(150);
            builder.Property(r=>r.UF).IsRequired().HasMaxLength(2);
            builder.Property(r=>r.IdSolicitante).IsRequired();
            builder.Property(r=>r.RJ_Datadaaplicacao).IsRequired();
            builder.Property(r => r.DataSolicitacao).IsRequired();

            builder.HasOne(r=>r.Solicitante)
                .WithMany(s=>s.Relatorios)
                .HasForeignKey(r=>r.IdSolicitante)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
