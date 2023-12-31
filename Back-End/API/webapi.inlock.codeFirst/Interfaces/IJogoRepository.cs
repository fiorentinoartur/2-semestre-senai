﻿using webapi.inlock.codeFirst.Domains;

namespace webapi.inlock.codeFirst.Interfaces
{
    public interface IJogoRepository
    {
        List<Estudio> Listar();
        Estudio BuscarPorId(Guid id);
        void Cadastrar(Estudio estudio);
        void Atualizar(Guid id, Estudio estudio);
        void Deletar(Guid id);
    }
}
