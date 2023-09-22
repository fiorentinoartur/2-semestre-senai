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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEvento _tiposEventoRepository { get; set; }

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_tiposEventoRepository.Listar());
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tipoEvento);

                return Ok("Tipo de Evento cadastrado com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);
                return Ok("Tipo de Evento excluido com sucesso!!!");
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
                return Ok(_tiposEventoRepository.BuscarPorId(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, TiposEvento tipoEvento) 
        { 
        try
            {
                _tiposEventoRepository.Atualizar(id, tipoEvento);
                return Ok("Tipo de Evento atualizado com Sucesso");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

