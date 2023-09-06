using Microsoft.AspNetCore.Http.HttpResults;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi_.Domains;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Security.Principal;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogo
    {
        private string stringConexao = "Data Source = NOTE14-S14; Initial Catalog = Inlock_Games; User Id = sa; Pwd = Senai@134";

        // private string stringConexao = "Data Source = ARTUR; Initial Catalog = Inlock_Games; User Id = sa; Pwd = Arcos@2020";
        public void Cadastrar(JogoDomain jogo)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string insert = $"INSERT INTO Jogo VALUES(@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(insert,con)) 
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamneto", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    cmd.ExecuteNonQuery();
                    

                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = $"SELECT Jogo.IdJogo,Estudio.Nome AS Estudio,Jogo.Nome,Jogo.Descricao,Jogo.DataLancamento,Jogo.Valor FROM Jogo JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            Nome = rdr["Nome"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToByte(rdr["Valor"]),
               
                        
                            Estudio = new EstudioDomain()
                            {
                                Nome = rdr["Estudio"].ToString()
                            }


                        };
                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}
