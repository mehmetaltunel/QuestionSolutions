using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;

namespace QuestionSolutions.SharedKernel.MediatR.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {

    }
    
    public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Result> where TQuery : IQuery
    {
    }    
}
