using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FerramentaAPI.Presentation.Middleware {
    public class GlobalExceptionHandler(ILogger <GlobalExceptionHandler> logger) : IExceptionHandler {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken) {

            logger.LogError(exception, "{Message}", exception.Message);

            var problemDetails = new ProblemDetails {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Erro no servidor"
            };

            context.Response.StatusCode = problemDetails.Status.Value;

            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;

            //context.Response.ContentType = "application/json";

            //context.Response.StatusCode = exception switch {
            //    ArgumentException => (int)HttpStatusCode.BadRequest, // 400 para validações
            //    KeyNotFoundException => (int)HttpStatusCode.NotFound, // 404 para não encontrado
            //    _ => (int)HttpStatusCode.InternalServerError // 500 para outros erros
            //};


        }
            
    }
}
