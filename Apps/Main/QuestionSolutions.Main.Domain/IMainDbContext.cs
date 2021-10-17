using QuestionSolutions.Main.Domain.Shcemas.Main;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.Main.Domain
{
    public interface IMainDbContext : IDbContext
    {
        IMainSchema Main { get; }
    }
}