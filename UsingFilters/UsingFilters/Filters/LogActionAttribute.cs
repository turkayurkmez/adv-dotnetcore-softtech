using Microsoft.AspNetCore.Mvc;

namespace UsingFilters.Filters
{
    public class LogActionAttribute : TypeFilterAttribute
    {
        public LogActionAttribute() : base(typeof(SampleActionFilter))
        {

        }
    }
}
