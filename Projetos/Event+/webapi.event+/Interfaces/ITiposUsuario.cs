using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface ITiposUsuario
    {
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(Guid id);
        void Cadastrar(TiposUsuario tipoUsuario);
        void Atualizar(Guid id, TiposUsuario tipoUsuario);
        void Deletar(Guid id);
    }
}
