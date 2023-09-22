using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class PresencasRepository : IPresencaEvento
    {
        private readonly EventContext c;

        public PresencasRepository()
        {
            c = new EventContext();
        }

        public void Atualizar(Guid id, PresencasEvento presenca)
        {
            PresencasEvento presencaBuscada = BuscarPorId(id);

            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = presenca.Situacao;
                presencaBuscada.IdEvento = presenca.IdEvento;
                presencaBuscada.IdUsuario = presenca.IdUsuario;

                c.PresencasEvento.Update(presencaBuscada);

                c.SaveChanges();
            }
            else
                return;
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            return c.PresencasEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;
        }

        public void Deletar(Guid id)
        {
            PresencasEvento presencaBuscada = c.PresencasEvento.Find(id)!;

            if (presencaBuscada != null)
            {
                c.PresencasEvento.Remove(presencaBuscada);
            }

            c.SaveChanges();
        }

        public void Cadastrar(PresencasEvento presenca)
        {
            c.PresencasEvento.Add(presenca);

            c.SaveChanges();
        }

        public List<PresencasEvento> Listar()
        {
            return c.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMinhasPresencas(Guid id)
        {
            return c.PresencasEvento.Where(p => p.IdUsuario == id).ToList();

        }
    }
}
