using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly HealthContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthContext();
        }
        void IUsuario.Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);
            if(usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
            }
            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        void IUsuario.Cadastrar(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);

            ctx.SaveChanges();
        }

        void IUsuario.Deletar(Guid id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        Usuario IUsuario.GetById(Guid id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            return usuarioBuscado;
        }

        List<Usuario> IUsuario.Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
