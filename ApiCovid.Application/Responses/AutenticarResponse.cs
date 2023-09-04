using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Responses
{
    public class AutenticarResponse
    {
        public int Status { get; set; }
        public string Mensagem { get; set; }
        public string AccessToken { get; set; }
        public SolicitanteResponse Solicitante { get; set; }
    }
}
