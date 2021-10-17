using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuestionSolutions.SharedKernel.MediatR.Models
{
    public class Result
    {
        [JsonProperty("requestId")]
        public string      RequestId { get; private set; }
        [JsonProperty("errors"   )]
        public List<Error> Errors    { get; private set; }
        [JsonProperty("isSuccess")]
        public bool        IsSuccess => Errors == null || Errors.Count == 0;

        /// <summary>
        /// 
        /// </summary>
        public Result()
        {
            Errors = new List<Error>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        protected Result (Error error)
        {
            (Errors ??= new List<Error>()).Add(error);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        protected Result (params Error[] errors)
        {
            (Errors ??= new List<Error>()).AddRange(errors);
        }        
        
        public static Result WithSuccess (                    ) => new (      );
        public static Result WithFailure (       Error error  ) => new (error);
        public static Result WithFailure (params Error[] error) => new (error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public Result SetError(Error error)
        {
            (Errors ??= new List<Error>()).Add(error);

            return this;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public Result SetError(params Error[] errors)
        {
            (Errors ??= new List<Error>()).AddRange(errors);

            return this;
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result SetRequestId(string id)
        {
            RequestId = id;

            return this;
        }        
    }

    public class Result<TData> : Result
    {
        [JsonProperty("data")]
        public TData Data { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Result()
        {
            Data = default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        protected Result(TData data)
        {
            Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        protected Result (Error error) : base(error)
        {
            Data = default;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        protected Result (params Error[] errors) : base(errors)
        {
            Data = default;
        }

        public     static Result<TData> WithSuccess(       TData   data  ) => new (data  );        
        public new static Result<TData> WithFailure(       Error   error ) => new (error );
        public new static Result<TData> WithFailure(params Error[] errors) => new (errors);     
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Result<TData> SetData(TData data)
        {
            Data = data;

            return this;
        }        
    }

    public class PaginationResult<TData> : Result<TData>
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pagination"></param>
        protected PaginationResult(TData data, Pagination pagination) : base(data)
        {
            Pagination = pagination;
        }
    }
}
