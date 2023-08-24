using System.Data.SqlClient;
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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomains genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomains BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomains novoGenero)
        {
            //Declara a conexão passando a string de conexão como parâmetro 
           using(SqlConnection con = new SqlConnection(stringConexao))
            { 
                //Declara a query que será executada 
              string queryInsert = "INSERT INTO Genero(Nome) VALUES('"+ novoGenero.Nome +"')";

                //Declara o SqlCommand passando  query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executar a query  (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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

