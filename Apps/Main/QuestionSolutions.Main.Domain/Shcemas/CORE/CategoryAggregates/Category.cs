using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates
{
    public class Category : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}