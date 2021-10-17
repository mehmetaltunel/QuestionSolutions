using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace QuestionSolutions.SharedKernel.MediatR.Models
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; private set; }

        public ErrorModel ErrorModel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Error()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private Error(string message)
        {
            Message = message;
        }
        private Error(ErrorModel errorModel)
        {
            ErrorModel = errorModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        private Error(Exception exception)
        {
            Message = exception.Message;
        }

        public static Error WithMessage  (string           message  ) => new Error(message  );
        public static Error WithMessage  (ErrorModel      errorModel  ) => new Error(errorModel  );

        public static Error WithMessages (params string[]  messages ) => new Error(string.Join('\n', messages));
        public static Error WithException(Exception exception) => new Error(exception);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Error SetMessage(string message)
        {
            Message = message;

            return this;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public Error SetMessages(params string[] messages)
        {
            Message = string.Join('\n', messages);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Message;
        }
    }

    public class ErrorModel
    {
        public string Method { get; set; }
        public string Schema { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }
    }
}
