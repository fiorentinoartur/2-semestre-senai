using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository= new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario) 
        {
            try
            {
           _usuariosRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
