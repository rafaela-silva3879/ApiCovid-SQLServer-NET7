using ApiCovid.Domain.Interfaces.Repositories;
using ApiCovid.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }
        public void BeginTransation()
        {
            _transaction = _dataContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public ISolicitanteRepository SolicitanteRepository
        => new SolicitanteRepository(_dataContext);
        
        public IRelatorioRepository RelatorioRepository
       => new RelatorioRepository(_dataContext);

        
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}