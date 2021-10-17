using QuestionSolutions.SharedKernel.MediatR.Query;

namespace QuestionSolutions.Main.Application.Queries.Category.GetById
{
    public class Query : IQuery<CategoryGetByIdDto>
    {
        public long Id { get; set; }        
    }
}