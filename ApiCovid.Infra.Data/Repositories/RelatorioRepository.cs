using ApiCovid.Domain.Interfaces.Repositories;
using ApiCovid.Domain.Models;
using ApiCovid.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Infra.Data.Repositories
{
    public class RelatorioRepository : BaseRepository<Relatorio, Guid>, IRelatorioRepository
    {
        private readonly DataContext? _dataContext;
        public RelatorioRepository(DataContext? dataContext)
        : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}