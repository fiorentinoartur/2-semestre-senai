using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Utils;

namespace webapi.health_clinic.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly HealthContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
           Usuario usuarioBuscado = ctx.Usuario
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    TipoDeUsuario = new TiposDeUsuario
                    {
                        Titulo = u.TipoDeUsuario.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email);

            if(usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                if(confere)
                {
                    return usuarioBuscado;
                }
            }
            return null;
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
          usuario.Senha =  Criptografia.GerarHash(usuario.Senha);
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
            Usuario usuarioBuscado = ctx.Usuario.Include(t => t.TipoDeUsuario).FirstOrDefault(idBanco => idBanco.IdUsuario == id);
            return usuarioBuscado;
        }

        List<Usuario> IUsuario.Listar()
        {
            return ctx.Usuario.Include(t => t.TipoDeUsuario).ToList();
        }
    }
}
