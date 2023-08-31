using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.manha.Domains;
using webapi.Filmes.manha.Interfaces;
using webapi.Filmes.manha.Repositories;

namespace webapi.Filmes.manha.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(string Email, string Senha)
        {
            try
            {
                UsuarioDomain buscarUsuario = _usuarioRepository.Login(Email, Senha);

                return Ok(buscarUsuario);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
