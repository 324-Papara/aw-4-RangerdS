using Pa.Base.Response;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentValidation;
using Pa.Api.Services;

namespace Pa.Api.MiddleWares
{
    public class ErrorHandlerMiddleware
    {
        private readonly LogService logService;
        private readonly RequestDelegate next;
        private readonly string logFilePath = "Logs/ErrorHandlerLog.txt";

        public ErrorHandlerMiddleware(RequestDelegate next, LogService logService)
        {
            this.next = next;
            this.logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                // Log general exception
                await logService.LogToFile(logFilePath, "Error: " + ex.Message + " Inner Message: " + ex.InnerException?.Message);

                // Create an modified ApiResponse object
                var response = new ApiResponse(false, "There is an error: " + ex.Message + " Inner Message: " + ex.InnerException?.Message);

                // Set the response status code and content type
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Write the response
                var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

                // Ensure the response body is written
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
