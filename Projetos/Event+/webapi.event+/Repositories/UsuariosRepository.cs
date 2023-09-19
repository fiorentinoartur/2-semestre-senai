using Microsoft.EntityFrameworkCore;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Utils;

namespace webapi.event_.Repositories
{
    public class UsuariosRepository : IUsuario
    {
        private readonly EventContext _eventContext;

        public UsuariosRepository()
        {
            _eventContext = new EventContext();
        }
        public Usuario BuscaPorId(Guid id)
        {
            try
            {
                Usuario usuario = _eventContext.Usuario
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    TipoUsuario = new TiposUsuario
                    {
                        Titulo = u.TipoUsuario.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id);

                if(usuario != null)
                {
                    return usuario;
                }
                return null;
            }
            catch(Exception e) 
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.FirstOrDefault(u => u.Email == email);

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
            catch(Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                _eventContext.Usuario.Add(usuario);
                _eventContext.SaveChanges(); 

            }
            catch(Exception) 
            {
                throw;
            }
         
        }
    }
}
