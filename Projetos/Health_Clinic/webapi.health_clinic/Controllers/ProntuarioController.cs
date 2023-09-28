using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Repositories;

namespace webapi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuario _prontuarioRepository { get; set; }

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(_prontuarioRepository.Listar());
            }
            catch(Exception e) 
            {
            return BadRequest(e.Message);
            }


        }
        [HttpPost]
        public IActionResult Post(Prontuario prontuario) 
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);
                return Ok("Prontuário cadastrado com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return Ok("Prontuário excluído com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);
                return Ok("Prontuário atualizado com sucesso!!!");
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
                return Ok(_prontuarioRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
