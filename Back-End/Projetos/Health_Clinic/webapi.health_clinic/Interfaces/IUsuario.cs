using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        void Atualizar(Guid id, Usuario usuario);
        List<Usuario> Listar();
        Usuario GetById(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
