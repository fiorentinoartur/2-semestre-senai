using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class TiposDeUsuarioRepository : ITiposDeUsuario
    {
        private readonly HealthContext ctx;
        public TiposDeUsuarioRepository()
        {
            ctx = new HealthContext();
        }
        public void Cadastrar(TiposDeUsuario tipoDeUsuario)
        {
            ctx.TipoDeUsuario.Add(tipoDeUsuario);

            ctx.SaveChanges();
        }
    }
}
