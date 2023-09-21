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
    }
}
