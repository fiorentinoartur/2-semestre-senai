using System.Data.SqlClient;
using webapi.Filmes.manha.Domains;
using webapi.Filmes.manha.Interfaces;

namespace webapi.Filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do Banco de dados
        /// Autenticação: 
        ///    -Windows: Integrated Security = true
        ///    -SqlServer: User Id = sa ; Pwd = Senha
        /// </summary>

        private string stringConexao = "Data Source = NOTE14-S14; Intial Catalog = Filmes_Manha; User Id = sa; Pwd = Senai@134";
        public void AtualizarUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtulizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Genero VALUES(@IdGenero, @Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
