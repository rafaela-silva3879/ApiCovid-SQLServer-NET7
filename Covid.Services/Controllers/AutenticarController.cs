using ApiCovid.Application.Commands;
using ApiCovid.Application.Interfaces;
using ApiCovid.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCovid.Services.Controllers
{

    [Route("api/covid")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly ISolicitanteAppService? _solicitanteAppService;
        public AutenticarController(ISolicitanteAppService? solicitanteAppService)
        {
            _solicitanteAppService = solicitanteAppService;
        }


        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AutenticarResponse), 200)]
        public IActionResult Post(AutenticarCommand command)
        {
            var response = _solicitanteAppService.Autenticar(command);
            return StatusCode(200, response);
        }
    }

}
