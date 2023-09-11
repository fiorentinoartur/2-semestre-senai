using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogo
    {

        List<JogoDomain> ListarTodos();
        List<JogoDomain> ListarJogos();

        void Cadastrar(JogoDomain jogo);
    }
}
