using System;
using System.Threading;
using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.MediatR.Abstractions;
using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace QuestionSolutions.SharedKernel.MediatR.Query
{
    public abstract class QueryHandlerBase<TRequest, TResponse> : HandlerBase, IQueryHandler<TRequest, TResponse> 
        where TRequest : IQuery<TResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        protected QueryHandlerBase()
        {
        }           
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        protected QueryHandlerBase(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        protected QueryHandlerBase(ILogger logger) : base(logger)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        protected QueryHandlerBase(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected abstract Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }
    }
    
    public abstract class QueryHandlerBase<TRequest> : HandlerBase, IQueryHandler<TRequest> where TRequest : IQuery
    {
        /// <summary>
        /// 
        /// </summary>
        protected QueryHandlerBase()
        {
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        protected QueryHandlerBase(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        protected QueryHandlerBase(ILogger logger) : base(logger)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        protected QueryHandlerBase(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }           
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected abstract Task<Result> HandleAsync(TRequest request, CancellationToken cancellationToken);        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }
    }        
}