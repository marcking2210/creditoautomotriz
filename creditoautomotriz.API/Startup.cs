using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entities.Models;
using creditoautomotriz.Infrastructure;
using creditoautomotriz.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace creditoautomotriz.API
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<DbCreditoAutomotrizContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
            });
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IVehiculoRepository, VehiculoRepository>();
            services.AddTransient<IPatioRepository, PatioRepository>();
            services.AddTransient<IEjecutivoRepository, EjecutivoRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IClientePatioRepository, ClientePatioRepository>();
            services.AddTransient<ISolicitudCreditoRepository, SolicitudCreditoRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
