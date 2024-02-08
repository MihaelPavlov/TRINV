using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using TRINV.Domain.Common.Exceptions;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Utilities;

namespace TRINV.StartUp.Middlewares
{
    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ValidationExceptionHandlerMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                var error = exception.Message;

                if (exception is BaseDomainException baseDomainException)
                {
                    error = baseDomainException.Error;
                    result = SerializeObject(new OperationResult() { InitialException = new DomainException(error) });
                }
                else
                {
                    //TODO: Handle the case if someone doesn't use our infrasatructure exceptions using the IError class
                    // For example if someone decide to throw new ArgumentNullException. We don't want such kind of exceptions but it's possible
                    //result = SerializeObject(new OperationResult() { InitialException = new UnknownException(error) });

                }

            }

            return context.Response.WriteAsync(result);
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }

    public static class ValidationExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}
