using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class PacienteRepository : IPaciente
    {
        private readonly HealthContext ctx;
        public PacienteRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Paciente paciente)
        {
          Paciente pacienteBuscado = ctx.Paciente.Find(id);

            if(pacienteBuscado != null) 
            {
            pacienteBuscado.Nome= paciente.Nome;
            pacienteBuscado.CPF= paciente.CPF;
            }

            ctx.Paciente.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Paciente paciente)
        {
           ctx.Paciente.Add(paciente);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente paciente = ctx.Paciente.Find(id);

            ctx.Paciente.Remove(paciente);

            ctx.SaveChanges();
        }

        public Paciente GetById(Guid id)
        {
            Paciente paciente = ctx.Paciente.Find(id);
            return paciente;
        }

        public List<Paciente> Listar()
        {
           return ctx.Paciente.ToList();
        }
    }
}
