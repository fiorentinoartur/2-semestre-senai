using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    internal class EstudioRepository : IEstudioRepository
    {
        // private string stringConexao = "Data Source = NOTE14-S14; Initial Catalog = Filmes_Manha; User Id = sa; Pwd = Senai@134";
        private string stringConexao = "Data Source = ARTUR; Initial Catalog = Filmes; User Id = sa; Pwd = Arcos@2020";

        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                { 
                 rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["Id"]),

                            Nome = rdr["Nome"].ToString()
                        };
                        listaEstudio.Add(estudio);
                    }
                }
            }
        }
    }
}
