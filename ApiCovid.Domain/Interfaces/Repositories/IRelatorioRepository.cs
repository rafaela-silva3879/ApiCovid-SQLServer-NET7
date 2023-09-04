using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Interfaces.Repositories
{
    public interface IRelatorioRepository : IBaseRepository<Relatorio, Guid>
    {
    }
}
