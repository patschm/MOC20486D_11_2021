using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Veilig.IdentityWare;

namespace Veilig
{
    public class Startup
    {
        private string conStr = @"Server=.\sqlexpress;Database=VeiligDb;Trusted_Connection=True;MultipleActiveResultSets=true;";

       public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(opts => {
                opts.UseSqlServer(conStr);
            });
            services.AddIdentity<MyUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();

            // Optioneel. Dit is default
            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Account/Login";
            });

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts=> {
            //    opts.LoginPath = "/Account/Login";
            //});
            services.AddAuthorization(opts=> {
                opts.AddPolicy("circus", pol => {
                    pol.RequireClaim(ClaimTypes.Actor, "Clown");
                });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
  
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
