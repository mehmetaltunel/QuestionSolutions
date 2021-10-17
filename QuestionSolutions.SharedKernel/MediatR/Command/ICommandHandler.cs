using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;

namespace QuestionSolutions.SharedKernel.MediatR.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>> where TRequest : ICommand<TResponse>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest, Result> where TRequest : ICommand
    {
    }
}
