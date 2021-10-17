using Npgsql;

namespace QuestionSolutions.SharedKernel.SeedWork.Contexes
{
    public class PostgreSqlDbContext : DbContext, IPostgreSqlDbContext
    {
        public PostgreSqlDbContext(string connectionString, int commandTimeout)
        {
            Connection = new NpgsqlConnection(connectionString);
        }
    }
}