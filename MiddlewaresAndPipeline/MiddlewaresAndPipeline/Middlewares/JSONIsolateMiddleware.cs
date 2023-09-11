using System.Text;

namespace MiddlewaresAndPipeline.Middlewares
{
    public class JSONIsolateMiddleware
    {
        private readonly RequestDelegate _next;

        public JSONIsolateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST" && httpContext.Request.ContentType.StartsWith("application/json"))
            {
                using var reader = new StreamReader(httpContext.Request.Body);
                var json = await reader.ReadToEndAsync();
                var content = Encoding.UTF8.GetBytes(json);
                var stream = new MemoryStream(content);
                stream.Write(content, 0, content.Length);
                httpContext.Request.Body = stream;
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                httpContext.Items["json"] = json;
            }

            await _next(httpContext);
        }
    }
}
