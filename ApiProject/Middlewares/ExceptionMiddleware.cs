using ApiProject.Wrappers;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ApiProject.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext,ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext httpContext,Exception exception)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            var serviceResponse = new ServiceResponse<string>(null);
            
            if(exception.GetType() == typeof(ValidationException))
            {
                serviceResponse.StatusCode = (int)HttpStatusCode.BadRequest;

                var validationException = (List<FluentValidation.Results.ValidationFailure>)((ValidationException)exception).Errors;
                string[] errors = validationException.Select(x => x.ErrorMessage).ToArray();

                serviceResponse.Errors = errors;
            }
            else
            {
                serviceResponse.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorMessage = (exception.InnerException != null) ? exception.InnerException.Message : exception.Message;
                serviceResponse.Errors[0] = errorMessage;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Serialize(serviceResponse, options);
            return httpContext.Response.WriteAsync(result);
        }
    }
}
