using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]  
    public class ComentariosController : ControllerBase
    {
        private IComentario _comentarioRepository {  get; set; }

        public ComentariosController()
        {
               _comentarioRepository = new ComentariosRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }    
        
        [HttpPost]
        [Authorize]
        public IActionResult Post(ComentariosEvento comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);
                return Ok("Comentário cadastrado com sucesso!!!");
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }      
        
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return Ok("Comentário excluido com Sucesso!!!");
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }     
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.GetById(id));
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }  

    }
}
