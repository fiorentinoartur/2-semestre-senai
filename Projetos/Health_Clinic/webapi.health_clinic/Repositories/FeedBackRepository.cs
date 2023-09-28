using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class FeedBackRepository : IFeedBacks
    {
        private readonly HealthContext ctx;

        public FeedBackRepository()
        {
            ctx = new HealthContext();  
        }
        public void Atualizar(Guid id, FeedBacks feedBack)
        {
           FeedBacks buscarFeedBack = ctx.FeedBack.Find(id);

            if (buscarFeedBack != null) 
            { 
            buscarFeedBack.Descricao = feedBack.Descricao;
            }
            ctx.FeedBack.Update(buscarFeedBack);

            ctx.SaveChanges();
        }

        public void Cadastrar(FeedBacks feedBack)
        {
           ctx.FeedBack.Add(feedBack);

            ctx.SaveChanges();  
        }

        public void Deletar(Guid id)
        {
            FeedBacks feedBackBuscado = ctx.FeedBack.Find(id);
            ctx.FeedBack.Remove(feedBackBuscado);
            ctx.SaveChanges();
        }

        public FeedBacks GetById(Guid id)
        {

            FeedBacks feedBackBuscado = ctx.FeedBack.Find(id);
            return feedBackBuscado;
        }

        public List<FeedBacks> Listar()
        {
            return ctx.FeedBack.ToList();
        }
    }
}
