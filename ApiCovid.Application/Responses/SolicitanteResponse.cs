using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Responses
{
    /// <summary>
    /// Modelo de dados para retornar a resposta de um command
    /// contendo os dados do usuário que foi processado
    /// </summary>
    public class SolicitanteResponse
    {
        public Guid IdSolicitante { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
    }
}
