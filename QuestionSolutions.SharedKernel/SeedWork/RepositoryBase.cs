using System.Data;

namespace QuestionSolutions.SharedKernel.SeedWork
{
 public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IDbConnection  DbConnection;

        protected readonly IDbTransaction DbTransaction;
        
        protected readonly int            CommandTimeout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection" ></param>
        /// <param name="dbTransaction"></param>
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction, int commandTimeout = 30)
        {
            DbConnection  = dbConnection;
            DbTransaction = dbTransaction;
        }
    }

    public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class where TId: struct
    {
        protected readonly IDbConnection  DbConnection;

        protected readonly IDbTransaction DbTransaction;
        
        protected readonly int            CommandTimeout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection" ></param>
        /// <param name="dbTransaction"></param>
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction, int commandTimeout = 30)
        {
            DbConnection  = dbConnection;
            DbTransaction = dbTransaction;
        }
    }

    public abstract class RepositoryBase
    {
        protected readonly IDbConnection  DbConnection;

        protected readonly IDbTransaction DbTransaction;
        
        protected readonly int            CommandTimeout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction, int commandTimeout = 30)
        {
            DbConnection   = dbConnection;
            DbTransaction  = dbTransaction;
            CommandTimeout = commandTimeout;
        }
    }
}