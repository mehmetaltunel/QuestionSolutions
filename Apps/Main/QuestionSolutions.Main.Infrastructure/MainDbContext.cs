using QuestionSolutions.Main.Domain;
using QuestionSolutions.Main.Domain.Shcemas.CORE;
using QuestionSolutions.Main.Infrastructure.Repositories.Schemas.CORE;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.Main.Infrastructure
{
    public class MainDbContext : PostgreSqlDbContext, IMainDbContext
    {
        public MainDbContext(string connectionString, int commandTimeout) : base(connectionString, commandTimeout)
        {
        }

        public ICORESchema CORE => new CORESchema(Connection, Transaction,"CORE", CommandTimeout);
    }
}