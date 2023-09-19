using Microsoft.EntityFrameworkCore;
using webapi.event_.Domains;

namespace webapi.event_.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<ComentariosEvento>ComentariosEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* optionsBuilder.UseSqlServer("Server = NOTE14-S14; DataBase =webapi.event+_codeFirst_Manha; user id = sa; Pwd = Senai@134; TrustServerCertificate=True;");  
            * */
            
            optionsBuilder.UseSqlServer("Server = ARTUR; DataBase =webapi.event+_codeFirst_Manha; user id = sa; Pwd = Arcos@2020; TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }


    }
}
