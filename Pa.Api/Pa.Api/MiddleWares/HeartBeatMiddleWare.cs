using System.Text.Json;

namespace Pa.Api.MiddleWares
{
    public class HeartBeatMiddleWare
    {
        private readonly RequestDelegate next;

        public HeartBeatMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/heartbeat"))
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize("Hello World!"));
                context.Response.StatusCode = 200;
                return;
            }

            await next.Invoke(context);
        }
    }
}
