using MediatR;
using Microsoft.Extensions.Logging;


namespace QuestionSolutions.SharedKernel.MediatR.Abstractions
{
    public abstract class HandlerBase
    {
        protected readonly IMediator Mediator;
        protected readonly ILogger   Logger;

        protected HandlerBase()
        {
        }        
        
        protected HandlerBase(IMediator mediator)
        {
            Mediator = mediator;
        }
        
        protected HandlerBase(ILogger logger)
        {
            Logger = logger;
        } 
        
        protected HandlerBase(IMediator mediator, ILogger logger)
        {
            Mediator = mediator;
            Logger   = logger;
        }          
    }
}