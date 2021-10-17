using QuestionSolutions.Main.Domain.Shcemas.CORE;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.Main.Domain
{
    public interface IMainDbContext : IDbContext
    {
        ICORESchema CORE { get; }
    }
}