using webapi.health_clinic.Domains;

namespace webapi.health_clinic.Interfaces
{
    public interface IConsulta
    {
        void Cadastrar(Consulta consulta);
        void Deletar(Guid id);
        void Atualizar(Guid id, Consulta consulta);
        List<Consulta> Listar();
        Consulta GetById(Guid id);
    }
}
