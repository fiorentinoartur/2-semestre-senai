using webapi.Filmes.manha.Domains;

namespace webapi.Filmes.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
