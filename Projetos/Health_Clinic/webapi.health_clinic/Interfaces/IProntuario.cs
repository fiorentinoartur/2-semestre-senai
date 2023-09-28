using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IProntuario
    {
        void Cadastrar(Prontuario prontuario);
        void Deletar(Guid id);
        void Atualizar(Guid id, Prontuario prontuario);
        List<Prontuario> Listar();
        Prontuario GetById(Guid id);
    }
}
