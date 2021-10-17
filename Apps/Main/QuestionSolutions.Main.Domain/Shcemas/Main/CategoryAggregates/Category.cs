namespace QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}