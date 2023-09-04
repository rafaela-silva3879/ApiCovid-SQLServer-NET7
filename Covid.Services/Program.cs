using ApiCovid.Services.Configurations;
using ApiCovid.Services.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "API de relatório de vacinados",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Rafaela Silva",
            Email = "rafaela.silva3879@outlook.com"
        }
    });
});


// Registre a classe de configuração DependencyInjectionConfiguration
DependencyInjectionConfiguration.ConfigureServices(builder.Services, builder.Configuration);

//o AutoMapper é adicionada somente APÓS a configuração das injeções de dependência
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

SecurityConfiguration.AddSecurity(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
//JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
