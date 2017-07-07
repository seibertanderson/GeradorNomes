using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewERP.Data.Local
{
    public class BancoDados
    {
        public string arquivoBancoDados { get; private set; }
        private SQLiteConnection bancoDados;

        public BancoDados(string arquivoBd)
        {
            arquivoBancoDados = arquivoBd;
            bancoDados = new SQLiteConnection(arquivoBancoDados);
        }

        public BancoDados()
        {
            arquivoBancoDados = "..\\data\\appdata.db";
            bancoDados = new SQLiteConnection(arquivoBancoDados);
        }

        public void CriarOuAtualizar()
        {
            List<Type> EntidadesPDV = Assembly.GetExecutingAssembly().GetTypes().Where(t => string.Equals(t.Namespace, "Database.Entidades", StringComparison.Ordinal)).ToList();
            foreach (var item in EntidadesPDV)
            {
                if (item.Name != "EntidadeBase") bancoDados.CreateTable(item);
            } 
        }

        public int IncluirRegistros(IEnumerable objetos)
        {
            return bancoDados.InsertAll(objetos);
        }

        public void ExecutaComando(string sql)
        {
            bancoDados.Execute(sql);
        }

        public void ZerarTabela(string entidade)
        {
            bancoDados.Execute("DELETE FROM " + entidade);
        }

        public void BeginTransaction()
        {
            bancoDados.BeginTransaction();
        }

        public void Commit()
        {
            bancoDados.Commit();
        }

        public void Rollback()
        {
            bancoDados.Rollback();
        }

        public void ZerarBaseDados()
        {
            List<Type> EntidadesPDV = Assembly.GetExecutingAssembly().GetTypes().Where(t => string.Equals(t.Namespace, "Database.Entidades", StringComparison.Ordinal)).ToList();
            foreach (var item in EntidadesPDV)
            {
                bancoDados.DeleteAll(item);
            }
        }
    }
}
