using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IPaciente
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid id);
        void Atualizar(Guid id, Paciente paciente);
        List<Paciente> Listar();
        Paciente GetById(Guid id);
    }
}
