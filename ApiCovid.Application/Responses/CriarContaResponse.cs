using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Responses
{
    /// <summary>
    /// Modelo de dados para resposta do comando
    /// de criação de conta de usuário na aplicação
    /// </summary>
    public class CriarContaResponse
    {
        public int? Status { get; set; }
        public string? Mensagem { get; set; }
        public SolicitanteResponse? Solicitante { get; set;}
    }
}
