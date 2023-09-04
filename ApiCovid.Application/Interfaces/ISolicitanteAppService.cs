using ApiCovid.Application.Commands;
using ApiCovid.Application.Responses;
using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Interfaces
{
    public interface ISolicitanteAppService : IDisposable
    {
        CriarContaResponse CriarConta(CriarContaCommand command);

        AutenticarResponse Autenticar(AutenticarCommand command);

        Solicitante GetById(Guid id);
    }
}
