using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using webapi.Filmes.manha.Domains;
using webapi.Filmes.manha.Interfaces;

namespace webapi.Filmes.manha.Repositories

{
    public class GeneroRepository : IGeneroRepository
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
        //Integrated Security = true
        public void AtualizarIdCorpo(GeneroDomains genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE  IdGenero = @IdGenero";

                

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void AtualizarIdUrl(int id, GeneroDomains genero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar um gênero através do Id
        /// </summary>
        /// <param name="id">Id do gênero a ser buscado</param>
        /// <returns>Objeto buscado ou null caso não seja encontrado</returns>
        public GeneroDomains BuscarPorId(int id)
        {
            //declara a conexão passando a string de conexão como parâmetros
            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                //declara o sql command cmd passando a query que será executada e a conexão como parametros
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                //abre a conexão com o banco de dados
                conn.Open();

                //declara a variavei para receber os valores da query 
                SqlDataReader rdr;

                //declara o sql command cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, conn))
                {
                    //passa o valor para o parâmetro IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomains generoBuscado = new GeneroDomains()
                        {
                            //atribui a propriedade idgenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //atribui a propriedade nome o valor da coluna "nome" da tabala do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };
                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }
                    //se não, retorna null
                    return null;
                }
            }

        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomains novoGenero)
        {
            //Declara a conexão passando a string de conexão como parâmetro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada 
                string queryInsert = $"INSERT INTO Genero(Nome) VALUES(@Nome)";

                //Declara o SqlCommand passando  query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Pasa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);
                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executar a query  (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um determinado gênero através do id
        /// </summary>
        /// <param name="idGenero">Id do objeto a ser deletado</param>
        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = $"Delete FROM Genero WHERE IdGenero = (@idGenero)";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos generos 
        /// </summary>
        /// <returns>Lista de objetos (gêneros) </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GeneroDomains> ListarTodos()
        {
            //Cria uma lista de objetos do tipo gênero
            List<GeneroDomains> listaGeneros = new List<GeneroDomains>();

            //Declara a sqlConnection passando a string de conexão como argumento
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero,Nome FROM Genero";

                //Abre a conexão com  banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declaração o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomains genero = new GeneroDomains()
                        {
                            //atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade nome o valor recebido rdr
                            Nome = rdr["Nome"].ToString()
                        };
                        //Adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);
                    };
                }

            }

            return listaGeneros;
        }


    }
}

