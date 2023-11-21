using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Repositories;

namespace webapi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasConsultaController : ControllerBase
    {
        private IPresencaConsulta _presencaConsultaRepository { get; set; }

        public PresencasConsultaController()
        {
            _presencaConsultaRepository = new PresencaConsultaRepository();
        }


        [HttpPost]
        public IActionResult Post(PresencasConsulta presencaConsulta)
        {
            try
            {
                _presencaConsultaRepository.Cadastrar(presencaConsulta);
                return Ok("O tipo de presença foi cadastrado com sucesso!!!");
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
    }
}
