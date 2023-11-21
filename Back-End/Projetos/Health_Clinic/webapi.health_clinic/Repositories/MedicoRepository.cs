using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class MedicoRepository : IMedico
    {
        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = ctx.Medico.Find(id);
            if(medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;
                medicoBuscado.Nome = medico.Nome;
            }
           
            ctx.Medico.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Medico medico)
        {
            ctx.Medico.Add(medico);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medico = ctx.Medico.Find(id);

            ctx.Medico.Remove(medico);

            ctx.SaveChanges();
        }

        public Medico GetById(Guid id)
        {
            Medico medico = ctx.Medico.Find(id);
            return medico;
        }

        public List<Medico> Listar()
        {
            return ctx.Medico.Include(e => e.Especialidade).Include(c => c.Clinica).Include(u => u.Usuario).Include(t => t.Usuario.TipoDeUsuario).ToList();
        }
    }
}
