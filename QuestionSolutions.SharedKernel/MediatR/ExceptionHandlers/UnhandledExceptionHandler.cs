using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using QuestionSolutions.SharedKernel.Accessors;
using QuestionSolutions.SharedKernel.MediatR.Models;
using QuestionSolutions.SharedKernel.Utilities;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace QuestionSolutions.SharedKernel.MediatR.ExceptionHandlers
{
    public class UnhandledExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException> where TException: Exception
        where TRequest : IRequest<TResponse>
        where TResponse: Result, new()
    {
        private readonly ILogger<TRequest>    _logger;
        //private readonly UserContextAccessor  _accessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UnhandledExceptionHandler(ILogger<TRequest> logger, IHttpContextAccessor httpContextAccessor/*, UserContextAccessor accessor*/)
        {
            _logger              = logger;
            _httpContextAccessor = httpContextAccessor;
            //_accessor            = accessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <param name="state"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
           // ErrorModel errorModel = new ErrorModel();

            using (LogContext.PushProperty("Request"       , request                                                                                      , true))
            //using (LogContext.PushProperty("UserContext"   , _accessor                                                                                    , true))
            using (LogContext.PushProperty("IPAddress"     , _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString()                   , true))
            using (LogContext.PushProperty("UserAgent",
                _httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"], true))
            using (LogContext.PushProperty("IsMobileDevice", StringUtil.IsMobileDevice(_httpContextAccessor?.HttpContext?.Request?.Headers?["User-Agent"]), true))
            {
                _logger.LogError(exception, "Method: {RequestMethod} Schema: {RequestSchema} Host: {RequestHost} Path: {RequestPath}", _httpContextAccessor?.HttpContext?.Request?.Method, _httpContextAccessor?.HttpContext?.Request?.Scheme, _httpContextAccessor?.HttpContext?.Request?.Host, _httpContextAccessor?.HttpContext?.Request?.Path);
            }
           /* errorModel.Host = _httpContextAccessor?.HttpContext?.Request.Host.ToString();
            errorModel.Method = _httpContextAccessor?.HttpContext?.Request.Method.ToString();
            errorModel.Path = _httpContextAccessor?.HttpContext?.Request.Path.ToString();
            errorModel.Schema = _httpContextAccessor?.HttpContext?.Request.Scheme.ToString();
            errorModel.Message = exception.Message;*/
            state.SetHandled(new TResponse().SetError(Error.WithMessage(exception.Message)).SetRequestId(_httpContextAccessor?.HttpContext?.TraceIdentifier) as TResponse);
            
            await Task.CompletedTask;
        }
    }
}
