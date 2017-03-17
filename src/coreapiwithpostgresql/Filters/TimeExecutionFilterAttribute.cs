using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace coreapiwithpostgresql.Filters
{
    public class TimeExecutionFilterAttribute : Attribute, IResultFilter
    {
        DateTime start;
        public void OnResultExecuting(ResultExecutingContext context)
        {
            start = DateTime.Now;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            DateTime end = DateTime.Now;
            double processTime = end.Subtract(start).TotalMilliseconds;
            context.HttpContext.Response.Headers.Add("Execution time, ms", processTime.ToString());
        }
    }
}