using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class ConsultaRepository : IConsulta
    {
        private readonly HealthContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if(consultaBuscada != null)
            {
                consultaBuscada.Data = consulta.Data;
            }
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();

        }

        public void Cadastrar(Consulta consulta)
        {
            ctx.Consulta.Add(consulta);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consulta = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(consulta);
            ctx.SaveChanges();
        }

        public Consulta GetById(Guid id)
        {
            Consulta consulta = ctx.Consulta.Find(id);
            return consulta;
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta.ToList();
        }
    }
}
