using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NewERP.Data.Local.Interfaces;
using SQLite;

namespace NewERP.Data.Local.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class, new()
    {
        private SQLiteConnection db;

        public RepositorioBase(BancoDados bancoDados)
        {
            this.db = new SQLiteConnection(bancoDados.arquivoBancoDados);
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> filtros)
        {
            return db.Find<TEntity>(filtros);
        }

        public TEntity BuscarPorId(int id)
        {
            return db.Find<TEntity>(id);
        }

        public TEntity BuscarPorId(long id)
        {
            return db.Find<TEntity>(id);
        }

        public IQueryable<TEntity> ComandoSql(string comandoSql)
        {
            return db.Query<TEntity>(comandoSql, null).AsQueryable();
        }

        public IQueryable<TEntity> ComandoSql(string comandoSql, List<object> parametros)
        {
            return db.Query<TEntity>(comandoSql, parametros).AsQueryable();
        }

        public IQueryable<TEntity> Consultar<TValue>(Expression<Func<TEntity, bool>> filtros, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            TableQuery<TEntity> query = db.Table<TEntity>();
            if (filtros != null) query = query.Where(filtros);
            if (orderBy != null) query = query.OrderBy<TValue>(orderBy);

            return query.ToList().AsQueryable();
        }

        public bool Deletar(TEntity obj)
        {
            int retorno = db.Delete(obj);
            return retorno.Equals(1);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TEntity Editar(TEntity obj)
        {
            db.Update(obj);
            return obj;
        }

        public TEntity Incluir(TEntity obj)
        {
            db.Insert(obj);
            return obj;
        }

        public IQueryable<TEntity> ListarTodos()
        {
            return db.Table<TEntity>().ToList().AsQueryable();
        }
    }
}
