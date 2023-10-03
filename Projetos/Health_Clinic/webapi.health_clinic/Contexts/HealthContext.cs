using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Contexts
{
    public class HealthContext : DbContext
    {
        public DbSet<TiposDeUsuario> TipoDeUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<FeedBacks> FeedBack { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PresencasConsulta> PresencaConsulta { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* optionsBuilder.UseSqlServer("Server = NOTE14-S14; DataBase = webapi.health_clinic; user id = sa; Pwd = Senai@134; TrustServerCertificate=True;");*/
           

             optionsBuilder.UseSqlServer("Server = ARTUR; DataBase =webapi.health_clinic; user id = sa; Pwd = Arcos@2020; TrustServerCertificate=True;");
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
