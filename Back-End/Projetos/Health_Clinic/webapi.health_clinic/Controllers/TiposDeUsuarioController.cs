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
    public class TiposDeUsuarioController : ControllerBase
    {
        private ITiposDeUsuario _tiposDeUsuarioRepository { get; set; }

        public TiposDeUsuarioController()
        {
            _tiposDeUsuarioRepository = new TiposDeUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TiposDeUsuario tipoDeUsuario)
        { 
        try
            {
                _tiposDeUsuarioRepository.Cadastrar(tipoDeUsuario);
                return Ok("Tipo de usuario cadastrado com sucesso!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
