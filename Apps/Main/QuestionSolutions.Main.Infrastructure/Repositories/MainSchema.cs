using System.Data;
using QuestionSolutions.Main.Domain.Shcemas.Main;
using QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates;
using QuestionSolutions.Main.Infrastructure.Repositories.Implementations;

namespace QuestionSolutions.Main.Infrastructure.Repositories
{
    public class MainSchema : IMainSchema
    {
        private readonly IDbConnection  _connection;
        private readonly IDbTransaction _transaction;
        private readonly int            _commandTimeout;

        public MainSchema(IDbConnection connection, IDbTransaction transaction, int commandTimeout)
        {
            _connection = connection;
            _transaction = transaction;
            _commandTimeout = commandTimeout;
        }

        public ICategoryRepository Category => new CategoryRepository(_connection, _transaction, _commandTimeout);
    }
}