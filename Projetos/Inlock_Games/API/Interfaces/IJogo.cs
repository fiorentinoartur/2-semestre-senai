using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogo
    {

        List<JogoDomain> ListarTodos();

        void Cadastrar(JogoDomain jogo);
    }
}
