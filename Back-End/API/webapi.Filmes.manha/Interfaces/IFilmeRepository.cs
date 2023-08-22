using webapi.Filmes.manha.Domains;

namespace webapi.Filmes.manha.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        void AtulizarIdCorpo(FilmeDomain filme);

        void AtualizarUrl(int id, FilmeDomain filme);

        void Deletar(int id);

        FilmeDomain BuscarPorId(int id);

    }
}
