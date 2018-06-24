using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LifeBoatCoreApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDefaultResponse, DefaultResponse>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDefaultResponse defaultResponse, ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Use(next =>
            {
                return async context =>
                {
                    logger.LogInformation("1-Request arriving");
                    if (context.Request.Path.StartsWithSegments("/cmf"))
                    {
                        await context.Response.WriteAsync("Custom Middleware Func<>!");
                        logger.LogInformation("2-Request fired.");
                        logger.LogInformation("3-Response with custom Middleware!");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("3-Response without custom Middleware!");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/welcome"
            });

            app.Run(async (context) =>
            {
                //var defaultResponseMessage = defaultResponse.GetDefaultReponseHardCoded();
                var defaultResponseMessage = defaultResponse.GetDefaultResponse();
                await context.Response.WriteAsync(defaultResponseMessage);
            });
        }
    }
}
