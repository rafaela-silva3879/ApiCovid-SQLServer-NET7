using ApiCovid.Domain.Interfaces.Repositories;
using ApiCovid.Domain.Interfaces.Security;
using ApiCovid.Domain.Interfaces.Services;
using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApiCovid.Domain.Services
{
    public class SolicitanteDomainService : ISolicitanteDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly ITokenSecurity _tokenSecurity;

        public SolicitanteDomainService(IUnitOfWork? unitOfWork, ITokenSecurity tokenSecurity)
        {
            _unitOfWork = unitOfWork;
            _tokenSecurity = tokenSecurity;
        }
        public void CriarConta(Solicitante solicitante)
        {
            #region Verificar se o nome e CPF informados já esta cadastrados
            if (_unitOfWork.SolicitanteRepository.Get
            (s => s.Nome.Equals(solicitante.Nome)) != null)
                throw new ArgumentException
                ("O nome informado já está cadastrado no sistema, tente outro.");

            if (_unitOfWork.SolicitanteRepository.Get
                (s => s.CPF.Equals(solicitante.CPF)) != null)
                throw new ArgumentException
                ("O CPF informado já está cadastrado no sistema, tente outro.");
            #endregion

            solicitante.Perfil = Perfil.BASIC;

            _unitOfWork.SolicitanteRepository.Add(solicitante);
        }


        public Solicitante Autenticar(string nome, string CPF)
        {
            #region Verificar se o solicitante não é válido para autenticação
            var solicitante = _unitOfWork.SolicitanteRepository.Get
            (s => s.Nome.Equals(nome) && s.CPF.Equals(CPF));
            if (solicitante == null)
                throw new ArgumentException
                ("Acesso negado. Solicitante inválido.");
            #endregion
            solicitante.AccessToken = _tokenSecurity.CreateToken(solicitante);
            return solicitante;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Solicitante GetById(Guid id)
        {
           return _unitOfWork.SolicitanteRepository.GetById(id);
        }
    }
}