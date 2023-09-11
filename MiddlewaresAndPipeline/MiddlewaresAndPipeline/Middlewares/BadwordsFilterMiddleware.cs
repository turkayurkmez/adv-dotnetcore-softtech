namespace MiddlewaresAndPipeline.Middlewares
{
    public class BadwordsFilterMiddleware
    {
        private readonly RequestDelegate _next;

        public BadwordsFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items.TryGetValue("json", out object? json))
            {
                var badWords = new List<string> { "kötü", "istenmeyen", "kelimeler" };
                var jsonContent = (string?)json;
                if (badWords.Any(jsonContent.Contains))
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new { description = "Bu yorumda istenmeyen kelimeler var!" });
                    return;
                }
            }

            await _next(context);
        }
    }
}
