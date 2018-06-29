using LifeBoatCoreApplication.Data;
using LifeBoatCoreApplication.Services.Contracts;
using LifeBoatCoreApplication.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LifeBoatCoreApplication
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LifeBoatCoreApplicationDbContext>(options => 
                                                                    options.UseSqlServer(_configuration.GetConnectionString("LifeBoatCoreApplication"))
                                                                   );

            services.AddSingleton<IDefaultResponse, DefaultResponse>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            //services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDefaultResponse defaultResponse, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            //app.UseDefaultFiles();
            //app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string>() { "boat.html" } });
            //app.UseFileServer();
            app.UseStaticFiles();
            
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            //Custom Middleware
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("1-Request arriving");
            //        if (context.Request.Path.StartsWithSegments("/cmf"))
            //        {
            //            await context.Response.WriteAsync("Custom Middleware Func<>!");
            //            logger.LogInformation("2-Request fired.");
            //            logger.LogInformation("3-Response with custom Middleware!");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("3-Response without custom Middleware!");
            //        }
            //    };
            //});

            //app.UseWelcomePage(new WelcomePageOptions {
            //    Path = "/welcome"
            //});

            app.Run(async (context) =>
            {
                //throw new Exception();
                //var defaultResponseMessage = defaultResponse.GetDefaultReponseHardCoded();
                //var defaultResponseMessage = defaultResponse.GetDefaultResponse();
                var defaultResponseMessage = "NotFound!";
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"{defaultResponseMessage}");
                //await context.Response.WriteAsync($"{defaultResponseMessage} [{env.EnvironmentName}]");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"); 
        }

        private Action Configuration() => 
    }
}
