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
using Prueba_Automapper.Interfaces;
using Prueba_Automapper.Middlewares;
using Prueba_Automapper.Models;
using Prueba_Automapper.Repository;
using Prueba_Automapper.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper
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
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba_Automapper", Version = "v1" });
            });

            services.AddDbContext<biblosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddScoped<IMlib_WithDTO, Mlib_WithDTO>();
            // se añade servicio para que funciones Loggin / Ilogin
            services.AddScoped<ILogin, Loggin>();
            services.AddLogging(builder => {
                builder//.AddConfiguration(configuration.GetSection("Logging"))
                  .AddSerilog(new LoggerConfiguration().WriteTo.File("serilog.txt").CreateLogger())
                  .AddConsole();
#if DEBUG
                builder.AddDebug();
#endif
            });
            
  

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba_Automapper v1"));
            }

            app.UseMiddleware<EjemploMiddleware>();

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
