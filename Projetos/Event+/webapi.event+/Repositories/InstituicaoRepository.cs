using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
             ctx = new EventContext();
        }
        public void Cadastrar(Instituicao instituicao)
        {
            ctx.Instituicao.Add(instituicao);

            ctx.SaveChanges();  
        }
    }
}
