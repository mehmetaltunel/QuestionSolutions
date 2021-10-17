using System.Threading;
using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.MediatR.Abstractions;
using QuestionSolutions.SharedKernel.MediatR.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace QuestionSolutions.SharedKernel.MediatR.Command
{
    public abstract class CommandHandlerBase<TRequest, TResponse> : HandlerBase, ICommandHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        protected CommandHandlerBase() 
        {
        }           
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        protected CommandHandlerBase(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        protected CommandHandlerBase(ILogger logger) : base(logger)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        protected CommandHandlerBase(IMediator mediator, ILogger logger) : base(mediator, logger)
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
    
    public abstract class CommandHandlerBase<TRequest> : HandlerBase, ICommandHandler<TRequest> where TRequest : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        protected CommandHandlerBase()
        {
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        protected CommandHandlerBase(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        protected CommandHandlerBase(ILogger logger) : base(logger)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        protected CommandHandlerBase(IMediator mediator, ILogger logger) : base(mediator, logger)
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