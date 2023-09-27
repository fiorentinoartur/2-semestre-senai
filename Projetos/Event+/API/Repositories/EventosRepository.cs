using Microsoft.EntityFrameworkCore;
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
          Evento eventoBuscado = ctx.Eventos.Find(id);
            if (eventoBuscado != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.IdEvento = evento.IdEvento;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;
            }

            ctx.Eventos.Update(eventoBuscado);
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            Evento eventoBuscado = ctx.Eventos.Include(e => e.Instituicao).Include(e => e.TipoEvento).FirstOrDefault(idd => idd.IdEvento == id);
       
            return eventoBuscado;
        }

        public void Cadastrar(Evento evento)
        {
            ctx.Eventos.Add(evento);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = ctx.Eventos.Find(id);
            
            ctx.Eventos.Remove(eventoBuscado);

            ctx.SaveChanges();

        }

        public List<Evento> Listar()
        {
         List<Evento> eventos = ctx.Eventos
    .Select(e => new Evento
    {
        IdEvento = e.IdEvento,
        NomeEvento = e.NomeEvento,
        Descricao = e.Descricao,
        DataEvento = e.DataEvento,
        Instituicao = new Instituicao
        {
            NomeFantasia = e.Instituicao.NomeFantasia,
        },
        TipoEvento = new TiposEvento
        {
            Titulo = e.TipoEvento.Titulo,
        }
    }).ToList();
            return eventos;
//return ctx.Eventos.Include(i => i.Instituicao).Include(t => t.TipoEvento).ToList();
        }
    }
}
