using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Interfaces.Services
{
    public interface ISolicitanteDomainService : IDisposable
    {
        void CriarConta(Solicitante solicitante);

        Solicitante Autenticar(string email, string senha);

        Solicitante GetById(Guid id);
    }
}
