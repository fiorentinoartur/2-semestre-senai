using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudio  _estudioRepository {  get; set; }

        public EstudioController() 
        {
        _estudioRepository = new EstudioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

            List<EstudioDomain> buscarEstudio = _estudioRepository.ListarTodos();
            return Ok(buscarEstudio);
            }
            catch (Exception e) 
            { 
            return BadRequest(e.Message);
            }
        }
    }
}
