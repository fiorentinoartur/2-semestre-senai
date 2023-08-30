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

        private string stringConexao = "Data Source = NOTE14-S14; Initial Catalog = Filmes_Manha; User Id = sa; Pwd = Senai@134";
        public void AtualizarUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtulizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Nome = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filme VALUES(@IdGenero, @Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = $"Delete FROM Filme WHERE IdFilme = (@IdFilme)";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", idFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de objetos

            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //DEclara a SqlConnection passando a string de conexão como argumento
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser usada
                string querySelectAll = "SELECT IdFilme,Filme.IdGenero,Filme.Titulo,Genero.Nome From Filme JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                //Abre a conexão
                con.Open();

                //Declara o SqldataReader para percorrer a tb do bd
                SqlDataReader rdr;

                //Declaração o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FilmeDomain filmes = new FilmeDomain()
                        {
                            //Atribui a propriedade IdFilme o valor recebido no rdr
                            IdFilme = Convert.ToInt32(rdr[0]),

                            //Atribi a propriedade nome o valor recebido rdr
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero= Convert.ToInt32(rdr["IdGenero"]),

                            Genero = new GeneroDomains()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };
                    //Adiciona cada objeto dentro da lista
                    listaFilmes.Add(filmes);
                    }
                }
            }
            return listaFilmes;
        }
    }
}
