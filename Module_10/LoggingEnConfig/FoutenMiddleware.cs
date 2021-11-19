using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingEnConfig
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FoutenMiddleware
    {
        private readonly RequestDelegate _next;

        public FoutenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
               
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FoutenMiddlewareExtensions
    {
        public static IApplicationBuilder UseFoutenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FoutenMiddleware>();
        }
    }
}
