using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuario
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext= new EventContext();  
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
           _eventContext.TiposUsuario.Add(tipoUsuario);
           _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
