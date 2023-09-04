using ApiCovid.Application.Commands;
using ApiCovid.Application.Responses;
using ApiCovid.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Application.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CriarContaCommand, Solicitante>()
            .AfterMap((command, model) =>
            {
                model.IdSolicitante = Guid.NewGuid();
              
            });
            CreateMap<Solicitante, SolicitanteResponse>();


            CreateMap<BuscarRelatorioCommand, Relatorio>()
                   .AfterMap((command, model) =>
                   {
                       model.IdRelatorio = Guid.NewGuid();
                       model.UF = "RJ";
                       model.DataSolicitacao=DateTime.Now;
                       model.Descricao = "Relatório Vacinas Pfizer aplicadas no RJ_" + command.RJ_Datadaaplicacao;
                       model.Fabricante = "PFIZER";                       
                   });
            CreateMap<Relatorio, RelatorioResponse>();


        }
    }
}
