using QuestionSolutions.Main.Domain;
using QuestionSolutions.Main.Domain.Shcemas.Main;
using QuestionSolutions.Main.Infrastructure.Repositories;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.Main.Infrastructure
{
    public class MainDbContext : PostgreSqlDbContext, IMainDbContext
    {
        public MainDbContext(string connectionString, int commandTimeout) : base(connectionString, commandTimeout)
        {
        }

        public IMainSchema Main => new MainSchema(Connection, Transaction, CommandTimeout);
    }
}