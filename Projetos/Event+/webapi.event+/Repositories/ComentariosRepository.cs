using Azure.Identity;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentariosRepository : IComentario
    {
        private readonly EventContext ctx;

        public ComentariosRepository()
        {
                ctx = new EventContext();
        }
        public void Cadastrar(ComentariosEvento comentario)
        {
            ctx.ComentariosEvento.Add(comentario);
            ctx.SaveChanges(); 
        }

        public void Deletar(Guid id)
        {
            ComentariosEvento comentario = ctx.ComentariosEvento.Find(id);
            ctx.ComentariosEvento.Remove(comentario);
            ctx.SaveChanges();
        }

        public ComentariosEvento GetById(Guid id)
        {
            return ctx.ComentariosEvento.Find(id);
        }

        public List<ComentariosEvento> Listar()
        {
           return ctx.ComentariosEvento.ToList();
        }
    }
}
