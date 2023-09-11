using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UsingFilters.Filters
{
    public class NullReferenceExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NullReferenceException)
            {
                var message = new
                {
                    Info = $"{context.ActionDescriptor.DisplayName} metodunda, null reference hatası oluştu",
                    Source = context.Exception.Source
                };
                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
