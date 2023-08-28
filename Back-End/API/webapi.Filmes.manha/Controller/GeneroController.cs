using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.manha.Domains;
using webapi.Filmes.manha.Interfaces;
using webapi.Filmes.manha.Repositories;

namespace webapi.Filmes.manha.Controller
{
    //Define que a routa de uma requisição será no seguinte formato
    //dominio/apinomeController
    //ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define o que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoinsts (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instância o objeto _generoRepository para que haj referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }
        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório 
        /// </summary>
        /// <returns>Retorna a resposta para o usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição 
                List<GeneroDomains> listaGenero = _generoRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status cod OK(200)
                return Ok(listaGenero);
            }
            catch (Exception e)
            {
                //Retorna um status codr BadRequest(400) e a mensagem do erro 
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{idGenero}")]

        public IActionResult Get(int idGenero)
    {
        try
        {
            GeneroDomains listaGenero = _generoRepository.BuscarPorId( idGenero);

                if (listaGenero == null)
                {
                    return NotFound("Nenhum gênero foi encontrado");
                }

                return Ok(listaGenero);
            
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
        /// <summary>
        /// Endpoint para cadastro que aciona o método e cadastra gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomains novoGenero)
        {
            try
            {

            //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
            _generoRepository.Cadastrar(novoGenero);

            //Retorna um status code 201 - Created
            return Ok(novoGenero);
            }
            catch (Exception e)
            {
                //retorna um status code 400(BadRequest) e a mensagem do erro
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{idGenero}")]

        public IActionResult Delete(int idGenero)
        {
            try
            {
                _generoRepository.Deletar(idGenero);

                return Ok(idGenero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]

        public IActionResult Put(GeneroDomains genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return Ok(genero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
