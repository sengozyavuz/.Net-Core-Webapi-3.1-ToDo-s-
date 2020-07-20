using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YS_EventManagement.Business.Abstract;
using YS_EventManagement.Business.Concrete;
using YS_EventManagement.DataAccess.Abstract;
using YS_EventManagement.DataAccess.Concrate;

namespace YS_EventManagement.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IToDoService, ToDoManager>();
            services.AddSingleton<IToDoRepository, ToDoRepository>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "ToDo Project";
                    doc.Info.Version = "1.0.0.";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Yavuz SENGOZ",
                        Url = "yavuzsegoz.com",
                        Email = "sengoz.yavuz@gmail.com",
                    };

            });
        });
        
    }   
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
