using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository _comentarioRepository = new ComentariosEventoRepository();

        //Início da configuração do Controller para a IA

        //Armazena dados do serviço da API externa(IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que recebe os dados necessários para acesso ao serviço externo
        /// </summary>
        /// <param name="contentModeratorClient">objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }
        [HttpPost("ComentarioIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento novoComentario)
        {
            try
            {
                if ((novoComentario.Descricao).IsNullOrEmpty())
                {
                    return BadRequest("A descricao do comentário não pode estar vazio ou nulo!");
                }

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false,false,null,true);


                if(moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;

                    _comentarioRepository.Cadastrar(novoComentario);
                }
                else
                {
                    novoComentario.Exibe= true;

                    _comentarioRepository.Cadastrar(novoComentario);
                }
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.Listar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetShow(Guid id) {

            try
            {
                return Ok(_comentarioRepository.ListarExibe(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetById(Guid idUsuario, Guid idEvento)
        {
            try
            {

                return Ok(_comentarioRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
