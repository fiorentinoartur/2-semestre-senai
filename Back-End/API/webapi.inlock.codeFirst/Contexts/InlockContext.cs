using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.Domains;

namespace webapi.inlock.codeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        //Definir as entidades do banco de dados

        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Define as opções de construção do banco(String Conexão)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ARTUR; DataBase =inlock_games_codeFirst_Manha; user id = sa; Pwd = Arcos@2020; TrustServerCertificate=True;");
              
            base.OnConfiguring(optionsBuilder);
        }



    }
}
