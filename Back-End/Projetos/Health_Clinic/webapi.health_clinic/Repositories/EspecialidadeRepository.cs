using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidade
    {
        private readonly HealthContext ctx;
        public EspecialidadeRepository()
        {
            ctx = new HealthContext();
        }
        public void Cadastrar(Especialidade especialidade)
        {
            ctx.Especialidade.Add(especialidade);   

            ctx.SaveChanges();
        }
    }
}
