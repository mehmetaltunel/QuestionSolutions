using System.Data;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.SharedKernel.SeedWork
{
  public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IDbContext
    {
        public T Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(T context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenConnection()
        {
            if (Context.Connection is { State: ConnectionState.Closed })
            {
                Context.Connection.Open();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            if (Context.Connection is not { State: ConnectionState.Closed })
            {
                Context.Connection.Close();
            }
        }

        /// <summary>
        /// Try to begin transaction
        /// </summary>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            Context.Transaction = Context.Connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Try to commit transaction
        /// </summary>
        public void CommitTransaction()
        {
            if (Context.Transaction != null)
            {
                try
                {
                    Context.Transaction.Commit();
                }
                catch
                {
                
                    Context.Transaction.Rollback();

                    throw;
                }                
            }
        }

        /// <summary>
        /// Try to rollback transaction
        /// </summary>
        /// <returns></returns>
        public void RollbackTransaction()
        {
            if (Context.Transaction != null)
            {
                Context.Transaction.Rollback();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (Context.Transaction != null)
            {
                Context.Transaction.Dispose();
                Context.Transaction = null;
            }
    
            if (Context.Connection != null)
            {
                switch (Context.Connection.State)
                {
                    case ConnectionState.Open:
                    case ConnectionState.Open | ConnectionState.Executing:
                    case ConnectionState.Open | ConnectionState.Fetching:
                        Context.Connection.Close();
                        break;
                }    
                
                Context.Connection.Dispose();
                Context.Connection = null;                
            }
        }
    }

}