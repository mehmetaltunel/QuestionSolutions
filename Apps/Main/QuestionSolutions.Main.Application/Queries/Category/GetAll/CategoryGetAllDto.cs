namespace QuestionSolutions.Main.Application.Queries.Category.GetAll
{
    public class CategoryGetAllDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}