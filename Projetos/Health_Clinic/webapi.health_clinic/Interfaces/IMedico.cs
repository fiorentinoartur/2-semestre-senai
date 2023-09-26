using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IMedico
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid id);
        void Atualizar(Guid id, Medico medico);
        List<Medico> Listar();
        Medico GetById(Guid id);
    }
}
