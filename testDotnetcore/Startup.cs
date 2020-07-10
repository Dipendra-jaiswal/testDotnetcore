using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace testDotnetcore
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> looger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions objPage = new DeveloperExceptionPageOptions();
                objPage.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(objPage);
            }


            //Binding default static pages
            //DefaultFilesOptions obj = new DefaultFilesOptions();
            //obj.DefaultFileNames.Clear();
            //obj.DefaultFileNames.Add("Test.html");

            FileServerOptions objFileServer = new FileServerOptions();
            objFileServer.DefaultFilesOptions.DefaultFileNames.Clear();
            objFileServer.DefaultFilesOptions.DefaultFileNames.Add("Test.html");



            // app.UseDefaultFiles(obj);
            // app.UseStaticFiles();

            app.UseFileServer(objFileServer);
            

            //app.UseRouting();

           // app.UseAuthentication();
           // app.UseAuthorization();

           // app.UseMyCustomMiddleware();

            //app.Use(async (context, next) =>
            //{
            //    looger.LogInformation("a1 start");
            //    await context.Response.WriteAsync("\ncustom display!");                
            //    await next();
            //    looger.LogInformation("a1 end");
            //});

            //app.Use(async (context, next) =>
            //{
            //    looger.LogInformation("a2 start");
            //    await context.Response.WriteAsync("\ncustom display-1!");
            //    await next();
            //    looger.LogInformation("a2 end");
            //});



            //app.Map("/miniurl", mapApp =>
            //{
            //    mapApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("\nuse of app.map!");
            //    });
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("helloworld"), mapApp =>
            //{
            //    mapApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("\nmore complex mini url");
            //    });
            //});

            app.Run(async (context) =>
            {
                //my changes
                //throw new Exception("dev exception");

                looger.LogInformation("a3 start");
                await context.Response.WriteAsync("\nHello World");
                await context.Response.WriteAsync("\n" + Process.GetCurrentProcess().ProcessName);
                await context.Response.WriteAsync("\n" + _config["mykey"]);
                looger.LogInformation("a3 end");
            });

            




            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
