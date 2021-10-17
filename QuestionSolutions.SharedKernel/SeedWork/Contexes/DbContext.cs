using System.Data;

namespace QuestionSolutions.SharedKernel.SeedWork.Contexes
{
    public abstract class DbContext : IDbContext
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public int            CommandTimeout { get; set; }
    }
}