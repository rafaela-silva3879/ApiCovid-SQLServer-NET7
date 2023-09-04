using ApiCovid.Domain.Valitations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Models
{
    public class Solicitante
    {
        public Guid IdSolicitante { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Perfil Perfil { get; set; }
        public string AccessToken { get; set; }

        public List<Relatorio>? Relatorios { get; set; }

        #region Validação dos dados do usuário
        public ValidationResult Validate
        => new SolicitanteValidation().Validate(this);
        #endregion
    }
    public enum Perfil
    {
        BASIC = 1,
        ADMIN = 2
    }
}
