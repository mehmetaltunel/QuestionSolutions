using System.Data;

namespace QuestionSolutions.SharedKernel.SeedWork.Contexes
{
    public interface IDbContext
    {
        IDbConnection  Connection  { get; set; }
        IDbTransaction Transaction { get; set; } 
    }
}