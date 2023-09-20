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
           TiposUsuario tipoUsuario = _eventContext.TiposUsuario
                .Select(u => new TiposUsuario
                {
                   IdTipoUsuario = u.IdTipoUsuario,
                   Titulo = u.Titulo,
           
                }).FirstOrDefault(u => u.IdTipoUsuario == id)!;

            return tipoUsuario;

        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
           _eventContext.TiposUsuario.Add(tipoUsuario);
           _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoUsuarioBuscado =
            
            _eventContext.TiposUsuario.Find(id);

            _eventContext.TiposUsuario.Remove(tipoUsuarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
