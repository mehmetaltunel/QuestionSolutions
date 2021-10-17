using System.Data;
using System.Threading.Tasks;
using Dapper;
using QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IDbConnection connection, IDbTransaction dbTransaction, int commandTimeout) : base(connection, dbTransaction, commandTimeout)
        {

        }

        public async Task<Category> GetByIdAsync(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int64);
            var sql = $@"select * from ""Main"".""ufn_tbl_Category_getById""(@id)";
            var response = await DbConnection.QueryFirstOrDefaultAsync<Category>(sql, parameters,
                transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response;
        }
    }
}