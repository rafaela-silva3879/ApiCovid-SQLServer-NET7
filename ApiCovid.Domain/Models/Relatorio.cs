using ApiCovid.Domain.Valitations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Models
{
    public class Relatorio
    {
        public Guid IdRelatorio { get; set; }
        public DateTime RJ_Datadaaplicacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Descricao { get; set; }
        public int QtdeVacinados { get; set; }      
        public string Fabricante { get; set; }
        public string UF { get; set; }
        public Guid IdSolicitante { get; set; }

        public Solicitante? Solicitante { get; set; }

        #region Validação dos dados do relatório
        public ValidationResult Validate
        => new RelatorioValidation().Validate(this);
        #endregion
    }
}
