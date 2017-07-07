using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NewERP.Data.Local.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : class, new()
    {
        TEntity Incluir(TEntity obj);
        TEntity Editar(TEntity obj);
        bool Deletar(TEntity obj);
        IQueryable<TEntity> ListarTodos();
        TEntity BuscarPorId(int id);
        TEntity Buscar(Expression<Func<TEntity, bool>> filtros);
        IQueryable<TEntity> Consultar<TValue>(Expression<Func<TEntity, bool>> filtros, Expression<Func<TEntity, TValue>> orderBy = null);
        IQueryable<TEntity> ComandoSql(string comandoSql);
        IQueryable<TEntity> ComandoSql(string comandoSql, List<object> parametros);
        void Dispose();
    }
}
