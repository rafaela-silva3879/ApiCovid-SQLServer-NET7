using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Interfaces.Services
{
    public interface IRelatorioDomainService : IDisposable
    {
        void Salvar(Relatorio relatorio);

        List<Relatorio> BuscarTodos();
    }
}
