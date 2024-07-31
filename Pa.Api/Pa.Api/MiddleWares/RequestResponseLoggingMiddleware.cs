using System.Text;
using Pa.Api.Services;

namespace Pa.Api.MiddleWares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly LogService logService;
        private readonly ILogger<RequestResponseLoggingMiddleware> logger;
        private readonly RequestDelegate next;
        private readonly string logFilePath = "Logs/RequestResponseLog.txt";

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger, LogService logService)
        {
            this.next = next;
            this.logger = logger;
            this.logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the request
            context.Request.EnableBuffering();
            var requestBody = await ReadRequestBody(context.Request);
            var requestLog = $"Incoming Request: {context.Request.Method} {context.Request.Path} {requestBody}";
            logger.LogInformation(requestLog);
            await logService.LogToFile(logFilePath, requestLog);

            // Copy a pointer to the original response body stream
            var originalResponseBodyStream = context.Response.Body;

            // Create a new memory stream to hold the response
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            // Continue down the Middleware pipeline, eventually returning to this class
            await next(context);

            // Log the response
            var responseBodyText = await ReadResponseBody(context.Response);
            var responseLog = $"Outgoing Response: {context.Response.StatusCode} {responseBodyText}";
            logger.LogInformation(responseLog);
            await logService.LogToFile(logFilePath, responseLog);

            // Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
            await responseBody.CopyToAsync(originalResponseBodyStream);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Position = 0;
            using var reader = new StreamReader(response.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            response.Body.Position = 0;
            return body;
        }
    }
}
