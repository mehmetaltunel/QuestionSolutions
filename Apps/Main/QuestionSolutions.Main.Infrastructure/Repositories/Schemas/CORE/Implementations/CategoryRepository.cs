using System.Data;
using System.Threading.Tasks;
using Dapper;
using QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Infrastructure.Repositories.Schemas.CORE.Implementations
{
    public class CategoryRepository : RepositoryBase<Category,long>, ICategoryRepository
    {
        public CategoryRepository(IDbConnection connection, IDbTransaction dbTransaction,string schemaName, int commandTimeout) : base(connection, dbTransaction,schemaName, commandTimeout)
        {

        }
    }
}