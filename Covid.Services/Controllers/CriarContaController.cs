using ApiCovid.Application.Commands;
using ApiCovid.Application.Interfaces;
using ApiCovid.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiCovid.Services.Controllers
{
    [Route("api/covid")]
    [ApiController]
    public class CriarContaController : ControllerBase
    {
        private readonly ISolicitanteAppService? _solicitanteAppService;

        public CriarContaController(ISolicitanteAppService? solicitanteAppService)
        {
            _solicitanteAppService = solicitanteAppService;
        }

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponse), 201)]
        public IActionResult Post(CriarContaCommand command)
        {
                var response = _solicitanteAppService.CriarConta(command);
                return StatusCode(201, response);
         
        }
    }

}
