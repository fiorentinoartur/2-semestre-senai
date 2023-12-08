using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository _comentarioRepository = new ComentariosEventoRepository();


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception ex)
            { 
            return BadRequest(ex.Message);
            }

                  }
        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetById(Guid idUsuario, Guid idEvento) 
        {
            try
            {
                                                  
                return Ok(_comentarioRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
              }
        }

        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }
            catch (Exception ex) { 
            
            return BadRequest(ex.Message);}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _comentarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
