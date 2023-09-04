using ApiCovid.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Valitations
{
    internal class RelatorioValidation : AbstractValidator<Relatorio>
    {
        public RelatorioValidation()
        {
            RuleFor(s => s.IdRelatorio)
            .NotEmpty()
            .WithMessage("Id do relatório é obrigatória.");

            RuleFor(s => s.IdSolicitante)
               .NotEmpty()
               .WithMessage("Id do solicitante é obrigatória.");

            RuleFor(u => u.RJ_Datadaaplicacao)
                .NotEmpty()
                .WithMessage("Data da aplicação é obrigatória.");
        }

    }
}
