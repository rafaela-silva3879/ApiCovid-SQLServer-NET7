using ApiCovid.Domain.Interfaces.Repositories;
using ApiCovid.Domain.Interfaces.Services;
using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Services
{
    public class RelatorioDomainService : IRelatorioDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public RelatorioDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Relatorio> BuscarTodos()
        {
           var lista= _unitOfWork.RelatorioRepository.GetAll();
            return lista;
        }

        public void Salvar(Relatorio relatorio)
        {
            _unitOfWork.RelatorioRepository.Add(relatorio);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
