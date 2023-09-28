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
    public class FeedBackController : ControllerBase
    {
        private IFeedBacks _feedBacksRepository { get; set; }

        public FeedBackController()
        {
            _feedBacksRepository = new FeedBackRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_feedBacksRepository.Listar());
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
                _feedBacksRepository.Deletar(id);
                return Ok("O comentário foi excluído com sucesso!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(FeedBacks feedBack)
        {
            try
            {
                _feedBacksRepository.Cadastrar(feedBack);
                return Ok("O comentário foi cadastrado com sucesso!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Guid id, FeedBacks feedBack)
        {
            try
            {
                _feedBacksRepository.Atualizar(id, feedBack);
                return Ok("O comentário foi atualizado com sucesso!!");
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

                return Ok(_feedBacksRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}
