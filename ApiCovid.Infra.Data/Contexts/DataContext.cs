using ApiCovid.Domain.Models;
using ApiCovid.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Infra.Data.Contexts
{
    public class DataContext: DbContext
    {
        //construtor para inicializar a classe por meio de injeção de dependência
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<Relatorio> Relatorio { get; set; }

        //adicionar cada classe de mapeamento feita no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new SolicitanteMap());
            modelBuilder.ApplyConfiguration(new RelatorioMap());
        }
    }
}
