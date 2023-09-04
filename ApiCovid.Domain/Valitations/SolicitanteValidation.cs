using ApiCovid.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Valitations
{
    public class SolicitanteValidation : AbstractValidator<Solicitante>
    {
        public SolicitanteValidation()
        {
            RuleFor(s => s.IdSolicitante)
                .NotEmpty()
                .WithMessage("Id é obrigatória.");

            RuleFor(s => s.Nome)
                .NotEmpty()
                .Length(6, 150)
                .WithMessage("Nome é obrigatório e deve conter de 6 a 150 caracteres.")
                .Matches(@"^[A-Za-zãéúíáóÁÓÚÍÉÊ\s]+$")
                .WithMessage("Nome aceita somente letras.");

            RuleFor(s => s.CPF)
                .NotEmpty()
                .Length(11)
                .Matches(@"^\d{11}$")
                .WithMessage("CPF é obrigatório e deve conter 11 números.")
                .Must(ValidarCPF)
                .WithMessage("CPF inválido.");
        }

        private bool ValidarCPF(string cpf)
        {
            // Remover os caracteres de formatação
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificar se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
                return false;

            // Validar os dígitos verificadores
            int[] cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            int[] weights1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weights2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum1 = 0;
            for (int i = 0; i < 9; i++)
                sum1 += cpfArray[i] * weights1[i];

            int remainder1 = sum1 % 11;
            remainder1 = remainder1 < 2 ? 0 : 11 - remainder1;

            if (cpfArray[9] != remainder1)
                return false;

            int sum2 = 0;
            for (int i = 0; i < 10; i++)
                sum2 += cpfArray[i] * weights2[i];

            int remainder2 = sum2 % 11;
            remainder2 = remainder2 < 2 ? 0 : 11 - remainder2;

            return cpfArray[10] == remainder2;
        }
    }
}
