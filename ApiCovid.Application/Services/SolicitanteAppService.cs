using ApiCovid.Application.Commands;
using ApiCovid.Application.Interfaces;
using ApiCovid.Application.Responses;
using ApiCovid.Domain.Interfaces.Services;
using ApiCovid.Domain.Models;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Services
{
    public class SolicitanteAppService : ISolicitanteAppService
    {

        private readonly ISolicitanteDomainService? _solicitanteDomainService;
        private readonly IMapper? _mapper;

        public SolicitanteAppService
        (ISolicitanteDomainService? solicitanteDomainService, IMapper? mapper)
        {
            _solicitanteDomainService = solicitanteDomainService;
            _mapper = mapper;
        }
        public CriarContaResponse CriarConta(CriarContaCommand command)
        {
            //capturando os dados do usuário para criação da conta
            var solicitante = _mapper.Map<Solicitante>(command);

            //validando os dados do usuário
            var validate = solicitante.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            //executar a criação do usuário
            _solicitanteDomainService.CriarConta(solicitante);

            //retornar a resposta
            return new CriarContaResponse
            {
                Status = 201,
                Mensagem = "Criação de conta de solicitante realizada com sucesso.",
            Solicitante = _mapper.Map<SolicitanteResponse>(solicitante)
            };
        }

        public AutenticarResponse Autenticar(AutenticarCommand command)
        {
            //realizando a autenticação
            var solicitante = _solicitanteDomainService.Autenticar
            (command.Nome, command.CPF);
            //retornar a resposta
            return new AutenticarResponse
            {
                Status = 200,
                Mensagem = "Solicitante autenticado com sucesso.",
                AccessToken = solicitante.AccessToken,
                Solicitante = _mapper.Map<SolicitanteResponse>(solicitante)
            };
        }

        public Solicitante GetById(Guid id)
        {
            return _solicitanteDomainService.GetById(id);
        }

        public void Dispose()
        {
            _solicitanteDomainService.Dispose();
        }


    }
}
