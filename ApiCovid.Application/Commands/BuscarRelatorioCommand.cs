using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Commands
{
    public class BuscarRelatorioCommand
    {
        public Guid IdSolicitante { get; set; }
        public DateTime RJ_Datadaaplicacao { get; set; }
        public int QtdeVacinados { get; set; }
    }
}
