using Microsoft.AspNetCore.Mvc.Filters;

namespace UsingFilters.Filters
{
    public class SampleActionFilter : IActionFilter
    {

        private readonly ILogger<SampleActionFilter> _logger;

        public SampleActionFilter(ILogger<SampleActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($" {DateTime.Now} Action Execution çalıştı");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($" {DateTime.Now} Action Executed çalıştı");

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($" {DateTime.Now} Result Executing çalıştı");

        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($" {DateTime.Now} Result Executed çalıştı");

        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation($" {DateTime.Now} Action  Execution asenkton çalıştı");
            return Task.CompletedTask;

        }

        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            _logger.LogInformation($" {DateTime.Now} Resut  Executing asenkton çalıştı");
            return Task.CompletedTask;

        }
    }
}
