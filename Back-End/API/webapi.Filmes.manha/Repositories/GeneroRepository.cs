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

        public void Cadastrar(GeneroDomains novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomains> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
