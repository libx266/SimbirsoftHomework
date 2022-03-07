using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Tools;
using Task1.Middlewares;

namespace Task1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            services.AddTransient<AuthMiddleware>();
            services.AddTransient<LoggingMiddleware>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MobileApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();
            app.UseSwagger();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
            app.UseEndpoints(e =>
            {
                e.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
                e.MapGet("/kurwa", async context => await context.Response.WriteAsync(EncodingConvert.Utf8ToWin1251(Properties.Resources.String1)));
                e.MapControllers();
            });
        }
    }
}
