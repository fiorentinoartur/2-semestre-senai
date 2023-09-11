using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi_.Domains;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudio
    {
        //private string stringConexao = "Data Source = NOTE14-S14; Initial Catalog = Inlock_Games; User Id = sa; Pwd = Senai@134";

        private string stringConexao = "Data Source = ARTUR; Initial Catalog = InLock_Games; User Id = sa; Pwd = Arcos@2020";
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();
            List<JogoDomain> listaJogo = new List<JogoDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = $"SELECT Estudio.Nome AS Estudio,Jogo.Nome As Jogo FROM Estudio INNER JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio ORDER BY Estudio.Nome, Jogo.Nome";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {


                        JogoDomain jogo = new JogoDomain()
                        {
                            Nome = rdr["Jogo"].ToString(),
                            Estudio = new EstudioDomain()
                            {
                                Nome = rdr["Estudio"].ToString()
                            }

                        };

                        listaJogo.Add(jogo);

                    }
                }
            }
            return null;
        }
    }
}
