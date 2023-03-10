using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Website_Backend.Data;
using Travel_Website_Backend.Repository;
using Travel_Website_Backend.Repository.EventRepository;

namespace Travel_Website_Backend
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
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("TravelWebsiteDb")));
            services.AddControllers();
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();
            services.AddCors(
                options =>
                {
                    var frontendUrl = configuration.GetValue<string>("frontend_url");
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();

                    });
                }

                 );
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel_Website_Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel_Website_Backend v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
