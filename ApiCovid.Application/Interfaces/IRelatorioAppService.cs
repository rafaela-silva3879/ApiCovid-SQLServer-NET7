using ApiCovid.Application.Commands;
using ApiCovid.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Interfaces
{
    public interface IRelatorioAppService
    {
        RelatorioResponse SalvarRelatorio(BuscarRelatorioCommand command);

        List<RelatorioResponse> BuscarTodos();
    }
}
