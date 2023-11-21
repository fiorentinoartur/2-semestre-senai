using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class ProntuarioRepository : IProntuario
    {
        private readonly HealthContext ctx;

        public ProntuarioRepository()
        {
            ctx = new HealthContext();  
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario prontuarioBuscado = ctx.Prontuario.Find(id);
            if(prontuarioBuscado != null)
            {
            prontuarioBuscado.Descricao = prontuario.Descricao;
            }
            ctx.Prontuario.Update(prontuarioBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Prontuario prontuario)
        {
           ctx.Prontuario.Add(prontuario);  
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Prontuario prontuarioBuscado = ctx.Prontuario.Find(id);

            ctx.Prontuario.Remove(prontuarioBuscado);

            ctx.SaveChanges();  
        }

        public Prontuario GetById(Guid id)
        {
            return ctx.Prontuario.Find(id);
        }

        public List<Prontuario> Listar()
        {
           return ctx.Prontuario.ToList();
        }
    }
}
