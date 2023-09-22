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
    public class EventosController : ControllerBase
    {
        private IEvento _eventoRepository { get; set; }

        public EventosController()
        {
            _eventoRepository = new EventosRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return Ok("Evento Cadastrado com sucesso!!!");
            }
            catch (Exception e) 
            { 
            return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() 
        { 
        try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e) 
            { 
            return BadRequest($"{e.Message}");
            }
        }
        [HttpDelete]
        [Authorize(Roles ="Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return Ok("Evento exluído com sucesso");
            }
            catch (Exception e) 
            {
            return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Evento evento, Guid id) 
        { 
        try
            {
                _eventoRepository.Atualizar(id, evento);
                return Ok("Evento atualizado com Sucesso!!");
            }
            catch(Exception e) 
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
 return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
