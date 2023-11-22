using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Sample.Domain;
using System.Data;

namespace KLO128.Calculator.Infra.D3ORM
{
    public class UnitOfWork : IUnitOfWork
    {
        private ID3Context D3Context { get; }

        private IDbConnection Connection { get; }

        public UnitOfWork(ID3Context D3Context, IDbConnection Connection)
        {
            this.D3Context = D3Context;
            this.Connection = Connection;
        }

        public void SaveParticularly()
        {
        }

        public TResult Transaction<TResult>(Func<TResult> func)
        {
            Connection.OpenIfNot();
            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                    var result = func();

                    transaction.Commit();

                    return result;
                }
                catch (Exception exp)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Transaction(Action action)
        {
            Connection.OpenIfNot();
            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                    action();

                    transaction.Commit();
                }
                catch (Exception exp)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
