namespace QuestionSolutions.Main.Application.Queries.Category.GetById
{
    public class CategoryGetByIdDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}