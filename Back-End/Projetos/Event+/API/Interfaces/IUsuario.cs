using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscaPorId(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);

    }
}
