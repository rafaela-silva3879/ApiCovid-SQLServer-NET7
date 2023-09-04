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
    public class RelatorioAppService : IRelatorioAppService
    {
       
        private readonly IRelatorioDomainService? _relatorioDomainService;
        private readonly ISolicitanteDomainService? _solicitanteDomainService;
        private readonly IMapper? _mapper;

        public RelatorioAppService(IRelatorioDomainService? relatorioDomainService, IMapper? mapper, ISolicitanteDomainService? solicitanteDomainService)
        {
            _relatorioDomainService = relatorioDomainService;
            _mapper = mapper;
            _solicitanteDomainService = solicitanteDomainService;
        }

        public List<RelatorioResponse> BuscarTodos()
        {
            var lista = new List<Relatorio>();
            lista = _relatorioDomainService.BuscarTodos();

            var listaResponse = new List<RelatorioResponse>();
            foreach(var item in lista)
            {
                var response = new RelatorioResponse();
                response = _mapper.Map<RelatorioResponse>(item);

                var solicitante = _solicitanteDomainService.GetById(item.IdSolicitante);

                if (solicitante != null)
                {
                    response.SolicitanteResponse = new SolicitanteResponse();
                    response.SolicitanteResponse= _mapper.Map<SolicitanteResponse>(solicitante);
                }
                listaResponse.Add(response);
            }
            return listaResponse;
    }

        public RelatorioResponse SalvarRelatorio(BuscarRelatorioCommand command)
        {
            //capturando os dados do usuário para criação da conta
            var relatorio = _mapper.Map<Relatorio>(command);

            //validando os dados do usuário
            var validate = relatorio.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _relatorioDomainService.Salvar(relatorio);

            var response = new RelatorioResponse();
            response = _mapper.Map<RelatorioResponse>(relatorio);

            var solicitante = _solicitanteDomainService.GetById(command.IdSolicitante);

            if (solicitante != null)
            {
                response.SolicitanteResponse=new SolicitanteResponse();
                response.SolicitanteResponse = _mapper.Map<SolicitanteResponse>(solicitante);
            }

            return response;
        }
    }
}
