using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //To serve the Swagger UI at the app's root (https://localhost:<port>/), set the RoutePrefix property to an empty string:

            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    options.RoutePrefix = string.Empty;
            //});

            //By default, Swashbuckle generates and exposes Swagger JSON in version 3.0 of the specification—officially called
            //the OpenAPI Specification. To support backwards compatibility, you can opt into exposing JSON in the 2.0 format instead.
            //This 2.0 format is important for integrations such as Microsoft Power Apps and Microsoft Flow that currently
            //support OpenAPI version 2.0. To opt into the 2.0 format, set the SerializeAsV2 property in Program.cs:

            //app.UseSwagger(options =>
            //{
            //    options.SerializeAsV2 = true;
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
