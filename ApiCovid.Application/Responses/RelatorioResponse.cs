using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Responses
{
    public class RelatorioResponse
    {
        public DateTime DataSolicitacao { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public Guid IdRelatorio { get; set; }
        public Guid IdSolicitante { get; set; }
        public DateTime RJ_Datadaaplicacao { get; set; }
        public string UF { get; set; }
        public int QtdeVacinados { get; set; }
        public SolicitanteResponse SolicitanteResponse { get; set; }
    }
}
