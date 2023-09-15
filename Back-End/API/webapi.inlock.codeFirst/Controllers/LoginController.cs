using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.Domains;
using webapi.inlock.codeFirst.Interfaces;
using webapi.inlock.codeFirst.Repositories;
using webapi.inlock.codeFirst.ViewModels;

namespace webapi.inlock.codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {

                Usuario buscarUsuario = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);
                return Ok(buscarUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
