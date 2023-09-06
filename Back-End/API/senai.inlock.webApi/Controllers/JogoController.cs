using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogo _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();

                return  Ok(listaJogo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(JogoDomain jogo)
        {
            try
            {

                _jogoRepository.Cadastrar(jogo);

            return Ok(jogo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                    }
            
        }
    }
}
