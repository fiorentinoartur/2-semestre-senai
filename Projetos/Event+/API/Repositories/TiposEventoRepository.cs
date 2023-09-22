using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TiposEventoRepository : ITiposEvento
    {
        private readonly EventContext ctx;

        public TiposEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            TiposEvento tipoEventoBuscado = ctx.TiposEvento.Find(id)!;

            if (tipoEventoBuscado != null) 
            {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;
            }
            
            ctx.TiposEvento.Update(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            TiposEvento tiposEvento = ctx.TiposEvento
                .Select(t => new TiposEvento
                 {
                     IdTipoEvento = t.IdTipoEvento,
                     Titulo = t.Titulo,
                 }).FirstOrDefault(t => t.IdTipoEvento == id)!;

            return tiposEvento;
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
           ctx.TiposEvento.Add(tipoEvento);   
           ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipoEvento = ctx.TiposEvento.Find(id);

            ctx.TiposEvento.Remove(tipoEvento);

            ctx.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
         return ctx.TiposEvento.ToList();
        }
    }
}
