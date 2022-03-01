using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Webmotors.Domain.Interfaces;
using Webmotors.Domain.Repository;
using Webmotors.Domain.Repository.Abstractions;
using Webmotors.infra;

namespace Webmotors.Repository.Api
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

            services.AddDbContext<WebmotorsAnunciosContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnectionSqlDocker"),
                    o => o.MigrationsAssembly("Webmotors.Api"))
                .EnableSensitiveDataLogging()
            );


            var assembly = AppDomain.CurrentDomain.Load("Webmotors.Application");
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Webmotors Anuncions Api", Version = "v1" });
            });

            services.AddTransient<IAnunciosRepository, AnunciosRepository>();
            services.AddTransient<IContext, WebmotorsAnunciosContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webmotors Anuncions Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WebmotorsAnunciosContext>();

                context.Seed();
            }
        }
    }
}
