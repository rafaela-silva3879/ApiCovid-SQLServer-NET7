using FluentValidation;
using Newtonsoft.Json;

namespace ApiCovid.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ArgumentException e)
            {

                await HandleExceptionAsync(context, e);
            }
            catch (ValidationException e)
            {

                await HandleExceptionAsync(context, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var error = string.Empty;
            switch (exception)
            {
                case ArgumentException:
                    context.Response.StatusCode = 400;
                    error = exception.Message;
                    break;
                case ValidationException:
                    context.Response.StatusCode = 400;
                    error = JsonConvert.SerializeObject
                        (((ValidationException)exception)
                        .Errors.Select(e => e.ErrorMessage).ToList());
                    break;
                default:
                    context.Response.StatusCode = 500;
                    error = exception.Message;
                    break;
            }
            await context.Response.WriteAsync(new ErrorResult
            {
                Status = context.Response.StatusCode,
                Error = error
            }.ToString());
        }

    }

    public class ErrorResult
    {
        public int? Status { get; set; }
        public string? Error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
