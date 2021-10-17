using System.Threading;
using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.Accessors;
using QuestionSolutions.SharedKernel.MediatR.Models;
using QuestionSolutions.SharedKernel.Utilities;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog.Context;

namespace QuestionSolutions.SharedKernel.MediatR.ExceptionHandlers
{
    public class PostgresExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException> where TException: NpgsqlException
        where TRequest : IRequest<TResponse>
        where TResponse: Result, new()
    {
        private readonly ILogger<TRequest>    _logger;
        //private readonly UserContextAccessor  _accessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="accessor"></param>
        public PostgresExceptionHandler(ILogger<TRequest> logger, IHttpContextAccessor httpContextAccessor/*, UserContextAccessor accessor*/)
        {
            _logger              = logger;
            _httpContextAccessor = httpContextAccessor;
           // _accessor            = accessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <param name="state"></param>
        /// <param name="cancellationToken"></param>
        public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            if (exception is NpgsqlException {SqlState: "P0001"} ex)
            {
                using (LogContext.PushProperty("Request"       , request                                                                                      , true))
               // using (LogContext.PushProperty("UserContext"   , _accessor                                                                                    , true))
                using (LogContext.PushProperty("IPAddress"     , _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString()                   , true)) 
                using (LogContext.PushProperty("UserAgent"     , _httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"]                           , true))
                using (LogContext.PushProperty("IsMobileDevice", StringUtil.IsMobileDevice(_httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"]), true))
                {
                    _logger.LogError(ex, "Method: {RequestMethod} Schema: {RequestSchema} Host: {RequestHost} Path: {RequestPath}", _httpContextAccessor?.HttpContext?.Request?.Method, _httpContextAccessor?.HttpContext?.Request?.Scheme, _httpContextAccessor?.HttpContext?.Request?.Host, _httpContextAccessor?.HttpContext?.Request?.Path);
                }                
                
                state.SetHandled(new TResponse().SetError(Error.WithMessage(ex.Message)).SetRequestId(_httpContextAccessor?.HttpContext?.TraceIdentifier) as TResponse);
            }
            
            await Task.CompletedTask;
        }
    }
}
