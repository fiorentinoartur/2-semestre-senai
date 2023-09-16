using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock.codeFirst.Contexts;
using webapi.inlock.codeFirst.Domains;
using webapi.inlock.codeFirst.Interfaces;
using webapi.inlock.codeFirst.Utils;

namespace webapi.inlock.codeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variável privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositório
        /// Toda vez que o repositório for instanciada,
        /// Ele terá acesso aos dados fornecidos pelo contexro
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }
        public Usuario Login(string email, string senha)
        {
            try {

                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);
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
            catch(Exception e)
            {
                throw;
            }
        }


        public void Cadastrar(Usuario usuario)
        {
            try
            {

            usuario.Senha = Criptografia.GerarHash(usuario.Senha);
       
            ctx.Add(usuario);
           
                ctx.SaveChanges();
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
