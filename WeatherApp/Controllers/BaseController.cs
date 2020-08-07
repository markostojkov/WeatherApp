using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherApp.Contracts.Utils.Result;

namespace WeatherApp.Controllers
{
    public abstract class BaseController
    {
        protected BaseController()
        {
        }

        protected static HttpStatusCode GetStatusCode(ResultType resultType)
        {
            HttpStatusCode statusCode;

            switch (resultType)
            {
                case ResultType.NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ResultType.Forbidden:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case ResultType.Conflicted:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case ResultType.Validation:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ResultType.Unauthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case ResultType.ServiceUnavailable:
                    statusCode = HttpStatusCode.ServiceUnavailable;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }

        protected IActionResult OkOrError<T>(Result<T> result)
        {
            IActionResult errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return new OkObjectResult(result.Value);
        }

        protected IActionResult OkOrError(ResultCommonLogic result)
        {
            IActionResult errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return new OkResult();
        }

        private IActionResult GetErrorResponse(ResultCommonLogic result)
        {
            if (result.IsFailure)
            {
                HttpStatusCode statusCode = GetStatusCode(result.ResultType);

                var errorResponse = new ObjectResult(result.Message)
                {
                    StatusCode = (int)statusCode
                };

                return errorResponse;
            }

            return null;
        }
    }
}
