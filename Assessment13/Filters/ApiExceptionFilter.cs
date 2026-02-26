using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Assessment13.Models;

namespace Assessment13.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Exception caught in Filter");

            var error = new ApiErrorResponse
            {
                StatusCode = 500,
                Message = "Filter handled exception",
                Details = context.Exception.Message
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}