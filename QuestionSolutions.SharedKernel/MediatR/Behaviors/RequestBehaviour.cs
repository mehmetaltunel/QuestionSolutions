using QuestionSolutions.SharedKernel.Accessors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.MediatR.Models;
using QuestionSolutions.SharedKernel.Utilities;
using Serilog.Context;

namespace QuestionSolutions.SharedKernel.MediatR.Behaviors
{
    public class RequestBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse: Result, new()
    {
        private readonly Stopwatch            _timer;
        private readonly ILogger<TRequest>    _logger;
        //private readonly UserContextAccessor  _accessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="accessor"></param>
        public RequestBehaviour(ILogger<TRequest> logger, IHttpContextAccessor httpContextAccessor/*, UserContextAccessor accessor*/)
        {
            _timer               = new Stopwatch();
            _logger              = logger;
            _httpContextAccessor = httpContextAccessor;
           // _accessor            = accessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _timer.Start();

                var response = await next();
                
                _timer.Stop();

                using (LogContext.PushProperty("Request"            , request                                                                                      , true))
                //using (LogContext.PushProperty("UserContext"        , _accessor                                                                                    , true))
                using (LogContext.PushProperty("IPAddress"          , _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString()                   , true)) 
                using (LogContext.PushProperty("UserAgent"          , _httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"]                           , true))
                using (LogContext.PushProperty("IsMobileDevice"     , StringUtil.IsMobileDevice(_httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"]), true))
                using (LogContext.PushProperty("ElapsedMilliseconds", _timer.ElapsedMilliseconds                                                                   , true))
                {
                    _logger.LogInformation("Method: {RequestMethod} Schema: {RequestSchema} Host: {RequestHost} Path: {RequestPath}", _httpContextAccessor?.HttpContext?.Request?.Method, _httpContextAccessor?.HttpContext?.Request?.Scheme, _httpContextAccessor?.HttpContext?.Request?.Host, _httpContextAccessor?.HttpContext?.Request?.Path);
                }

                return response;
            }
            catch
            {
                _timer.Stop();

                throw;
            }
        }
    }
}
