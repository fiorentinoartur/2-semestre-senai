using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        //private string stringConexao = "Data Source = NOTE14-S14; Initial Catalog = Inlock_Games; User Id = sa; Pwd = Senai@134";

        private string stringConexao = "Data Source = ARTUR; Initial Catalog = InLock_Games; User Id = sa; Pwd = Arcos@2020";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT IdUsuario, Email,Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha ";

            con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };
                    return usuario;
                    }
            return null;
                }
            }
        }
    }
}
