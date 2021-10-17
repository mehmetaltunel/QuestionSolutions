using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;

namespace QuestionSolutions.SharedKernel.MediatR.Query
{
    public interface IQuery : IRequest<Result>
    {

    }    
    
    public interface IQuery<TResult> : IRequest<Result<TResult>>
    {

    }
}
