using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.manha.Domains;
using webapi.Filmes.manha.Interfaces;
using webapi.Filmes.manha.Repositories;

namespace webapi.Filmes.manha.Controller
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que irá receber todos os métodos definidos a interação IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instância o objeto _filmeRepository para que haja referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados na requisição
                List<FilmeDomain> listaFilme = _filmeRepository.ListarTodos();

                return Ok(listaFilme);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //Fazendo chamada para o método cadastrar passando o objeto como parâmetro
                _filmeRepository.Cadastrar(novoFilme);

                //Retorna um status code 201 - Created
                return Ok(novoFilme); 
            }
            catch(Exception e)
            {
                // Retorna um status code 400(BadRequest) e a mensagem do erro
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{idFilme}")]

        public IActionResult Delete(int idFilme)
        {
            try
            {
                _filmeRepository.Deletar(idFilme);
                return Ok(idFilme);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
