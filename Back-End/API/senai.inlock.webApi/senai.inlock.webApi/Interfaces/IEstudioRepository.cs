using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain novoEstudio);
        List<EstudioDomain> ListarTodos();
        void AtualizarIdCorpo(EstudioDomain estudio);
        void Deletar(int idEstudio);
    }
}
