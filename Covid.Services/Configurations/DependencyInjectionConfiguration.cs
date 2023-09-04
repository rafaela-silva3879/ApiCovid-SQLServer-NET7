using ApiCovid.Domain.Interfaces.Repositories;
using ApiCovid.Application.Interfaces;
using ApiCovid.Application.Services;
using ApiCovid.Domain.Interfaces.Services;
using ApiCovid.Domain.Services;
using ApiCovid.Infra.Data.Contexts;
using ApiCovid.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiCovid.Infra.Security.Settings;
using ApiCovid.Domain.Interfaces.Security;
using ApiCovid.Infra.Security.Services;

namespace ApiCovid.Services.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            {
                //capturar a connectionstring do banco de dados (appsettings.json)
                var connectionstring = configuration.GetConnectionString("Conexao");

                services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));

                //mapear a injeção de dependência para a classe 'SqlServerContext' localizada
                //no projeto Repository (classe que irá fazer a conexão com o banco de dados)
                services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionstring));

                //mapear a injeção de dependencia das demais classes e interfaces do sistema
                services.AddTransient<ISolicitanteAppService, SolicitanteAppService>();
                services.AddTransient<ISolicitanteDomainService, SolicitanteDomainService>();
                services.AddTransient<ISolicitanteRepository, SolicitanteRepository>();

                services.AddTransient<IRelatorioAppService, RelatorioAppService>();
                services.AddTransient<IRelatorioDomainService, RelatorioDomainService>();
                services.AddTransient<IRelatorioRepository, RelatorioRepository>();


                services.AddTransient<ITokenSecurity, TokenSecurity>();

                services.AddTransient<IUnitOfWork, UnitOfWork>();

            }
        }
    }
}
