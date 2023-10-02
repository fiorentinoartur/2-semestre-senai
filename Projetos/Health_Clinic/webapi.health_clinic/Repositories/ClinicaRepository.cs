using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class ClinicaRepository : IClinica
    {
        private readonly HealthContext ctx;
        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }
        public void Cadastrar(Clinica clinica)
        {
            ctx.Clinica.Add(clinica);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica cliniciaBuscada = ctx.Clinica.Find(id);

            ctx.Clinica.Remove(cliniciaBuscada);

            ctx.SaveChanges();

            /*   Clinica clinicaDelete = ctx.Clinica.Find(id);

               Medico medicoDelete = clinicaDelete.Medico.ToList();



               foreach (var medico in medicoDelete)
               {
                   Consulta consultasDelete = medico.Consultas.ToList();
                   foreach (var consulta in consultasDelete)
                   {
                       FeedBacks feedBackDelete = consultasDelete.FeedBacks.ToList();

                       foreach (var feedBack in feedBackDelete)
                       {
                           ctx.FeedBack.Remove(feedBack);
                       }
                       ctx.Consulta.Remove(consulta);
                   }
                   ctx.Medico.Remove(medico);
               }
               ctx.Clinica.Remove(clinicaDelete);
               ctx.SaveChanges();
           }
            */


        }
    }
}

