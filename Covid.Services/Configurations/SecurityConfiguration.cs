using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiCovid.Services.Configurations
{
    /// <summary>
    /// definir a política de autenticação utilizada no projeto
    /// </summary>
    public class SecurityConfiguration
    {
        public static void AddSecurity(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme
                    = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(
            bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters
                = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes
                        (builder.Configuration.GetSection("TokenSettings").GetSection("SecretKey").Value)
                ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}