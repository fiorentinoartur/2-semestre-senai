using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IEvento
    {
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        void Atualizar(Guid id, Evento evento);


    }
}
