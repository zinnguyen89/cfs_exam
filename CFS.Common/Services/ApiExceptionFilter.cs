using CFS.Common.Exceptions;
using CFS.Common.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace CFS.Common.Services
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private ILogger<ApiExceptionFilter> _Logger;
        private IHostingEnvironment _env;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger, IHostingEnvironment env)
        {
            _Logger = logger;
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(EntityDomainException))
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { context.Exception.Message }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { context.Exception.Message }
                };

                if (_env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                context.Result = new InternalServerErrorObjectResponse(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }
    }
}
