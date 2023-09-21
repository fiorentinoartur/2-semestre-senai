using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class EventosRepository : IEvento
    {
        private readonly EventContext ctx;

        public EventosRepository()
        {
              ctx = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
            ctx.Eventos.Add(evento);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
           return ctx.Eventos.ToList();
        }
    }
}
