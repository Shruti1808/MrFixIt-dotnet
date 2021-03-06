﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MrFixIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MrFixIt
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

            //This method configures the required framework services for our application
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // adds the MVC service to the project.

            services.AddEntityFramework()
                .AddDbContext<MrFixItContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));



            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MrFixItContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

            // Configure method = Tells our app what frameworks to use.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            

            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();

            // app.UseMvc() tells our app that it will be using the MVC framework.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");

                //tells our app to use Index action of Account Controller to ensure user authentication.
            });

            // add some configuration to our app to tell it to use static files. Also, app.UseStaticFiles() needs to be before app.Run..., or the files will not load.

            app.UseStaticFiles();

            app.Run(async (error) =>
            {
                await error.Response.WriteAsync("You should not see this message. An error has occured.");
            });
        }
    }
}
