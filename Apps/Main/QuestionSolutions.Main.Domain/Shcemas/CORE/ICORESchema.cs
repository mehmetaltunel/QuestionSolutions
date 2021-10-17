using QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Domain.Shcemas.CORE
{
    public interface ICORESchema : ISchema
    {
        ICategoryRepository Category { get; }
    }
}