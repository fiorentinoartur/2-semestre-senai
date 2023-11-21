using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface ITiposEvento
    {
        List<TiposEvento> Listar();
        TiposEvento BuscarPorId(Guid id);
        void Cadastrar(TiposEvento tipoEvento);
        void Atualizar(Guid id,TiposEvento tipoEvento);
        void Deletar(Guid id);
    }
}
