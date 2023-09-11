using MiddlewaresAndPipeline.Middlewares;

namespace MiddlewaresAndPipeline.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseBadwordsFilter(this IApplicationBuilder app)
        {
            app.UseMiddleware<JSONIsolateMiddleware>();
            app.UseMiddleware<BadwordsFilterMiddleware>();
            return app;
        }
    }
}
