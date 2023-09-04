using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransation();
        void Commit();
        void Rollback();
        ISolicitanteRepository SolicitanteRepository { get; }
        IRelatorioRepository RelatorioRepository { get; }
    }
}
