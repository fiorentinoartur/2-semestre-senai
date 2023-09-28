using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IFeedBacks
    {
        void Cadastrar(FeedBacks feedBack);
        void Deletar(Guid id);
        void Atualizar(Guid id, FeedBacks feedBack);
        List<FeedBacks> Listar();
        FeedBacks GetById(Guid id);
    }
}
