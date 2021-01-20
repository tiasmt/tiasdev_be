using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using backend.Repository;
using backend.Services;
using System.IO;

namespace backend
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
             services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                        builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                        builder.WithOrigins("https://tiasdev.herokuapp.com").AllowAnyHeader().AllowAnyMethod();
                        builder.WithOrigins("http://tiasdev.herokuapp.com").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddScoped<IBlogPostStorage>(storage => new FileBlogPostStorage(@"./Repo/BlogPosts/"));
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
