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
    public class ConsultaController : ControllerBase
    {
        private IConsulta _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        { 
        try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception e) 
            { 
            return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return Ok("Consulta cadastrada com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpPut]
        public IActionResult Put(Consulta consulta, Guid id) 
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return Ok();
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
                _consultaRepository.Deletar(id);
                return Ok("Consulta excluída com sucesso!!!");
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
                return Ok(_consultaRepository.GetById(id));
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

    }
}
