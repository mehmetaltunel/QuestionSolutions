using QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Domain.Shcemas.Main
{
    public interface IMainSchema : ISchema
    {
        ICategoryRepository Category { get; }
    }
}