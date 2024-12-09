using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Exceptions
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }



        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            //RFCE 
            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unexpected error occurred....",
                Detail = exception.Message

            };


            switch (exception)
            {
                case BookNotFoundException notFoundException:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Title = "Resource not found...";
                    problemDetails.Detail = notFoundException.Message;
                    break;




                case BadRequestException badRequestException:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Bad request......";
                    problemDetails.Detail = badRequestException.Message;
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Title = "Internal server error....";
                    break;
            }



            var result = JsonSerializer.Serialize(problemDetails);
            return response.WriteAsync(result);
        }
    }
}
