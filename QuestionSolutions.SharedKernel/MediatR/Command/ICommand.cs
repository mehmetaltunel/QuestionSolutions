using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;

namespace QuestionSolutions.SharedKernel.MediatR.Command
{
    public interface ICommand : IRequest<Result>
    {

    }

    public interface ICommand<TResult> : IRequest<Result<TResult>>
    {

    }    
}
