using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.dbFirst.Domains;
using webapi.inlock.dbFirst.Interfaces;
using webapi.inlock.dbFirst.Repositories;

namespace webapi.inlock.dbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_estudioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
      

        [HttpGet("ListarJogos")]
        public IActionResult GetWhiteGames()
        {
            try
            {

                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
            return Ok(_estudioRepository.BuscarPorId(id));

            }
            catch(Exception e) 
            {
            return BadRequest($"{e.Message}");  
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id) 
        { 
        try
            {
                _estudioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch(Exception e) 
            {
                return BadRequest($"{e.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return Ok(204);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        [HttpPut]
        public IActionResult Put(Estudio estudio, Guid id)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);
                return Ok(204);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
