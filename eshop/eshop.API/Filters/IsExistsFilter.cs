using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public IsExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. action param'da id var m?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} fonksiyonuna id gönderin!" });
                return;
            }


            //2. varsa int mi?
            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} fonksiyonundaki id değeri int olmalı" });
                return;
            }
            //3. db'de var mı?

            if (!(await productService.IsExists(id)))
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı" });
            }
            await next();
        }
    }
}
