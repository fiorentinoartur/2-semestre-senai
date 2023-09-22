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
    public class PresencasController : ControllerBase
    {
        private readonly IPresencaEvento _presencaRepository;

        public PresencasController()
        {
            _presencaRepository = new PresencasRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(PresencasEvento presenca)
        {
            try
            {
                _presencaRepository.Cadastrar(presenca);
                return Ok("Presença cadastrada com sucesso!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return Ok("Presença excluída com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencasEvento presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
                return Ok("Presença atualizada com sucesso!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{idPresenca}")]
        [Authorize]
        public IActionResult ListaMinhasPresencas(Guid id)
        {
            try
            {
                List<PresencasEvento> minhasPresencas = _presencaRepository.ListarMinhasPresencas(id);

                return Ok(minhasPresencas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
