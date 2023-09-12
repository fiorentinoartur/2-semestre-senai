using webapi.inlock.dbFirst.Domains;

namespace webapi.inlock.dbFirst.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();
        List<Estudio> ListarComJogos();
        Estudio BuscarPorId(Guid id);
        void Cadastrar(Estudio estudio);
        void Atualizar(Guid id, Estudio estudio);
        void Deletar(Guid id);
    }
}
