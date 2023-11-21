using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IPresencaEvento
    {
        void Deletar(Guid id);
        List<PresencasEvento> Listar();
        PresencasEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, PresencasEvento presenca);
        List<PresencasEvento> ListarMinhasPresencas(Guid id);
        void Cadastrar(PresencasEvento presenca);
    }
}
