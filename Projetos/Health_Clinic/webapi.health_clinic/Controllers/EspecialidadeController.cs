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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidade _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
         try
             {
                _especialidadeRepository.Cadastrar(especialidade);

                return Ok("Especialidade cadastrada com sucesso!");
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
    }
}
