using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IComentario
    {
        void Deletar(Guid id);
        void Cadastrar(ComentariosEvento comentario);
        List<ComentariosEvento> Listar();
        ComentariosEvento GetById(Guid id);
    }
}
