using ApiCovid.Domain.Interfaces.Security;
using ApiCovid.Domain.Models;
using ApiCovid.Infra.Security.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Infra.Security.Services
{
    public class TokenSecurity : ITokenSecurity
    {
        private readonly IOptions<TokenSettings>? _tokenSettings;
        public TokenSecurity(IOptions<TokenSettings>? tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }
        public string CreateToken(Solicitante solicitante)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes
            (_tokenSettings.Value.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, solicitante.CPF),
                    new Claim(ClaimTypes.Role, solicitante.Perfil.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours
                    (_tokenSettings.Value.ExpirationInHours),
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}