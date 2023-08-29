using webapi.Filmes.manha.Domains;

namespace webapi.Filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoDeRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomains novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomains> ListarTodos();


        /// <summary>
        /// Atualizar objeto existente passando seu id pelo o corpo da requisição 
        /// </summary>
        /// <param name="genero">Objeto  atualizado (novas informações)</param>
        void AtualizarIdCorpo(GeneroDomains genero);

        /// <summary>
        /// Atualizar objeto existente passando se id pela Url
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="genero">Objeto atualizado(novas informações)</param>

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto através do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        GeneroDomains BuscarPorId(int id);
        void AtualizarIdUrl(GeneroDomains genero, int id);
    }
}
