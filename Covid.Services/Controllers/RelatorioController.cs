using ApiCovid.Application.Commands;
using ApiCovid.Application.Interfaces;
using ApiCovid.Application.Responses;
using ApiCovid.Application.Services;
using ApiCovid.Domain.Models;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Services.Controllers
{
    [Authorize]
    [Route("api/covid")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly string _searchUrl = "https://imunizacao-es.saude.gov.br/_search";
        private readonly string _username = "imunizacao_public";
        private readonly string _password = "qlto5t&7r_@+#Tlstigi";


        private readonly IRelatorioAppService? _relatorioAppService;
        public RelatorioController(IRelatorioAppService? relatorioAppService)
        {
            _relatorioAppService = relatorioAppService;
        }

        [Route("buscar-todos")]
        [HttpGet]
        [ProducesResponseType(typeof(List<RelatorioResponse>), 200)]
        public IActionResult Get()
        {
            var response = _relatorioAppService.BuscarTodos();
            return StatusCode(200, response);
        }

        [Route("buscar")]
        [HttpPost]
        [ProducesResponseType(typeof(RelatorioResponse), 200)]
        public async Task<IActionResult> Post(Guid idSolicitante, DateTime RJ_Datadaaplicacao)
        {

            var command = new BuscarRelatorioCommand();
            command.IdSolicitante = idSolicitante;
            command.RJ_Datadaaplicacao = RJ_Datadaaplicacao;
            //command.QtdeVacinados = 3;
            command.QtdeVacinados = await ObterQuantidadeTotalVacinados(RJ_Datadaaplicacao);

            var response = _relatorioAppService.SalvarRelatorio(command);

            return StatusCode(200, response);

        }

        private async Task<int> ObterQuantidadeTotalVacinados(DateTime dataAplicacao)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Definir as credenciais de autenticação
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_password}"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                // Construir o corpo da solicitação para obter a quantidade total de vacinados
                string requestBody = @"{
            ""query"": {
                ""bool"": {
                    ""must"": [
                        {
                            ""match"": {
                                ""vacina_fabricante_nome"": ""PFIZER""
                            }
                        },
                        {
                            ""match"": {
                                ""estabelecimento_uf"": ""RJ""
                            }
                        },
                        {
                            ""match"": {
                                ""vacina_dataAplicacao"": """ + dataAplicacao.ToString("yyyy-MM-dd") + @"""
                            }
                        }
                    ]
                }
            }
        }";
                HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                // Enviar a solicitação POST para obter a quantidade total de vacinados
                HttpResponseMessage response = await httpClient.PostAsync(_searchUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse the response content to get the total vaccinated count
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                int quantidadeTotalVacinados = jsonResponse.hits.total.value;
                return quantidadeTotalVacinados;
            }
        }

    }
}
