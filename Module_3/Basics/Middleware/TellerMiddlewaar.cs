using Basics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TellerMiddlewaar
    {
        private readonly RequestDelegate _next;
        private readonly ITellertje _teller;

        public TellerMiddlewaar(RequestDelegate next, ITellertje teller)
        {
            _next = next;
            _teller = teller;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _teller.Increment();
            Console.WriteLine(httpContext.Request.Headers["Accept"]);
            Console.WriteLine("Incoming!!!!!!");
            await _next(httpContext);
            Console.WriteLine("Outgoing!!!!!!!");
            //Console.WriteLine(httpContext.Response.ContentType);
            _teller.Increment();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TellerMiddlewaarExtensions
    {
        public static IApplicationBuilder UseTellerMiddlewaar(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TellerMiddlewaar>();
        }
    }
}
