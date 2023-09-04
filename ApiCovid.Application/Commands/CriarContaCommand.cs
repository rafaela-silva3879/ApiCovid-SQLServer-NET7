using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Commands
{
    /// <summary>
    /// Modelo de dados para a requisição de criação de conta de usuário
    /// </summary>
    public class CriarContaCommand
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
    }
}
