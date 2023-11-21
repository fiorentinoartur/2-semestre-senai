using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class PresencaConsultaRepository : IPresencaConsulta
    {
        private readonly HealthContext ctx;

        public PresencaConsultaRepository()
        {

            ctx = new HealthContext();
        }
        public void Cadastrar(PresencasConsulta presencaConsulta)
        {
           ctx.PresencaConsulta.Add(presencaConsulta);

            ctx.SaveChanges();
        }
    }
}
