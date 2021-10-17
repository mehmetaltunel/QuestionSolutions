using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using QuestionSolutions.SharedKernel.Utilities;

namespace QuestionSolutions.SharedKernel.SeedWork
{
    public abstract class RepositoryBase
    {
        protected readonly IDbConnection  DbConnection;

        protected readonly IDbTransaction DbTransaction;
        
        protected readonly int            CommandTimeout;
        protected readonly string         SchemaName;
        
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction,string schemaName, int commandTimeout = 30)
        {
            DbConnection   = dbConnection;
            DbTransaction  = dbTransaction;
            CommandTimeout = commandTimeout;
            SchemaName     = schemaName;
        }
        
    }
    public abstract class RepositoryBase<TEntity, TId> : RepositoryBase, IRepository<TEntity, TId> where TEntity : class where TId: struct
    {
        
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction,string schemaName, int commandTimeout ) : base(dbConnection, dbTransaction,schemaName, commandTimeout)
        {
            
        }
        
        public async virtual Task<TId> InsertAsync(TEntity input)
        {
            var properties = GenericUtil<TEntity>.GetGenericProperties(input);
            var prm = PostgreSqlFunctionSqlNameGenerateUtil.GetInsertOrUpdateFunctionParameters(properties, true);
            var sql = $@"select * from ""{SchemaName}"".""ufn_tbl_{typeof(TEntity).Name}_Insert""({prm.FuncParameters})";
            return await DbConnection.ExecuteScalarAsync<TId>(sql, prm.Parameters,commandType: CommandType.Text, transaction: DbTransaction,
                commandTimeout: CommandTimeout);
        }
        
        public async virtual Task<bool> UpdateAsync(TEntity input)
        {
            var properties = GenericUtil<TEntity>.GetGenericProperties(input);
            var prm = PostgreSqlFunctionSqlNameGenerateUtil.GetInsertOrUpdateFunctionParameters(properties, false);
            var sql = $@"select * from ""{SchemaName}"".""ufn_tbl_{typeof(TEntity).Name}_Update""({prm.FuncParameters})";
            return await DbConnection.ExecuteScalarAsync<bool>(sql, prm.Parameters,commandType: CommandType.Text, transaction: DbTransaction,
                commandTimeout: CommandTimeout);        }
        
        public async virtual Task<bool> DeleteAsync(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id",id);
            var sql = $@"select * from ""{SchemaName}"".""ufn_tbl_{typeof(TEntity).Name}_Delete""()";
            var response = await DbConnection.ExecuteScalarAsync<bool>(sql, parameters,
                commandType: CommandType.Text,transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response;        }
        
        public async virtual Task<IList<TEntity>> GetAllAsync()
        {
            var sql = $@"select * from ""{SchemaName}"".""ufn_tbl_{typeof(TEntity).Name}_getAll""()";
            var response = await DbConnection.QueryAsync<TEntity>(sql,
                transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response.ToList();
        }

        public async virtual Task<TEntity> GetByIdAsync(TId id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int64);
            var sql = $@"select * from ""{SchemaName}"".""ufn_tbl_{typeof(TEntity).Name}_getById""(@id)";
            var response = await DbConnection.QueryFirstOrDefaultAsync<TEntity>(sql, parameters,
                transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response;
        }
    }
}