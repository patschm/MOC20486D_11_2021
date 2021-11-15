using Basics.Middleware;
using Basics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics
{
    public class Startup
    {
        // Configureer je de Dependency Injector
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Configureer services");
            //services.AddTransient<ITellertje, BlaBla>();
            services.AddSingleton<ITellertje, Tellertje>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            //services.AddSession(opts => opts.Cookie.) ;

            services.AddControllersWithViews();
        }
        
        // Construeer de Request Pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("Configureer Request Pipeline");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMiddleware<TellerMiddlewaar>();
            app.UseTellerMiddlewaar();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapGet("/", async (context) =>
                //{
                //    IUnitOfWork uof = app.ApplicationServices.GetRequiredService<IUnitOfWork>();
                //    ITellertje teller = app.ApplicationServices.GetRequiredService<ITellertje>();// uof.CreateTellertje();
                //    teller.Increment();
                //    teller.Increment();
                //    teller.Increment();

                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
