using System.Data;
using QuestionSolutions.Main.Domain.Shcemas.CORE;
using QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates;
using QuestionSolutions.Main.Infrastructure.Repositories.Schemas.CORE.Implementations;

namespace QuestionSolutions.Main.Infrastructure.Repositories.Schemas.CORE
{
    public class CORESchema : ICORESchema
    {
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    private readonly int _commandTimeout;
    private readonly string _schemaName;
    public CORESchema(IDbConnection connection, IDbTransaction transaction,string schemaName, int commandTimeout)
    {
        _connection = connection;
        _transaction = transaction;
        _commandTimeout = commandTimeout;
        _schemaName = schemaName;
    }

    public ICategoryRepository Category => new CategoryRepository(_connection, _transaction,_schemaName, _commandTimeout);
    
    }
}