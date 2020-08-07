using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WeatherApp.Contracts.Utils.Result
{
    public class Result : ResultCommonLogic
    {
        private Result() : base(ResultType.Ok, isFailure: false, message: string.Empty)
        {
        }

        internal Result(ResultType resultType, string message) : base(resultType, isFailure: true, message: message)
        {
        }

        public static Result Conflicted(string message)
        {
            return new Result(ResultType.Conflicted, message);
        }

        public static Result<T> Conflicted<T>(string message)
        {
            return new Result<T>(ResultType.Conflicted, message);
        }

        public static Result Failed(string message)
        {
            return new Result(ResultType.InternalError, message);
        }

        public static Result<T> Failed<T>(string message)
        {
            return new Result<T>(ResultType.InternalError, message);
        }

        public static Result Forbidden(string message)
        {
            return new Result(ResultType.Forbidden, message);
        }

        // Generics
        public static Result<T> Forbidden<T>(string message)
        {
            return new Result<T>(ResultType.Forbidden, message);
        }

        public static Result Invalid(string message)
        {
            return new Result(ResultType.Validation, message);
        }

        public static Result<T> Invalid<T>(string message)
        {
            return new Result<T>(ResultType.Validation, message);
        }

        public static Result NotFound(string message)
        {
            return new Result(ResultType.NotFound, message);
        }

        public static Result<T> NotFound<T>(string message)
        {
            return new Result<T>(ResultType.NotFound, message);
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> OtherError<T>(ResultCommonLogic result)
        {
            return new Result<T>(result.ResultType, result.Message);
        }

        public static Result Unauthorized(string message)
        {
            return new Result(ResultType.Unauthorized, message);
        }

        public static Result<T> Unauthorized<T>(string message)
        {
            return new Result<T>(ResultType.Unauthorized, message);
        }

        public static Result ServiceUnavailable(string message)
        {
            return new Result(ResultType.ServiceUnavailable, message);
        }

        public static Result<T> ServiceUnavailable<T>(string message)
        {
            return new Result<T>(ResultType.ServiceUnavailable, message);
        }
    }

    public class Result<T> : ResultCommonLogic
    {
        public bool IsEmpty => Value?.Equals(Empty) ?? true;

        public T Value { get; }

        private static T Empty => default(T);

        internal Result(ResultType resultType, string message) : base(resultType, isFailure: true, message: message)
        {
            Value = Empty;
        }

        internal Result(T value) : base(ResultType.Ok, isFailure: false, message: string.Empty)
        {
            Value = value;
        }


        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Result.Ok();
            }

            return new Result(result.ResultType, result.Message);
        }
    }

    [DebuggerStepThrough]
    public abstract class ResultCommonLogic
    {
        private readonly string _message;

        public bool IsFailure { get; }

        public bool IsSuccess => !IsFailure;

        public string Message
        {
            get
            {
                if (IsSuccess)
                {
                    throw new InvalidOperationException("There is no error message for success.");
                }

                return _message;
            }
        }

        public ResultType ResultType { get; }

        protected ResultCommonLogic(ResultType resultType, bool isFailure, string message)
        {
            if (isFailure)
            {
                if (message.Length == 0)
                {
                    throw new ArgumentNullException(nameof(message), "There must be error message for failure.");
                }

                if (resultType == ResultType.Ok)
                {
                    throw new ArgumentException("There should be error type for failure.", nameof(resultType));
                }
            }
            else
            {
                if (message.Length > 0)
                {
                    throw new ArgumentException("There should be no error message for success.", nameof(message));
                }

                if (resultType != ResultType.Ok)
                {
                    throw new ArgumentException("There should be no error type for success.", nameof(resultType));
                }
            }

            ResultType = resultType;
            IsFailure = isFailure;
            _message = message;
        }
    }
}
