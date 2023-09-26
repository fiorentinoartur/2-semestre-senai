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
    }
}
