using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;

using Microsoft.OpenApi.Models;
using log4net.Config;
using MovieDetails.DBContexts;
using MovieDetails.Repository;

namespace MovieDetails
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Web API", Version = "1.0" });
            });
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MovieD")));
            services.AddTransient<IMovieRepository, MovieRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            loggerFactory.AddLog4Net();
           
            app.UseHttpsRedirection();

          

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Web API V1");

            });

           

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            //  loggerFactory.AddLog4Net();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
