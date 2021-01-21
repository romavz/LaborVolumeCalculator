using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using LaborVolumeCalculator.Localization;

namespace LaborVolumeCalculator
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
            services.AddMvc()
                .AddFluentValidation(fvc => 
                { 
                    fvc.RegisterValidatorsFromAssemblyContaining<Startup>();
                    fvc.ValidatorOptions.LanguageManager = new FluentValidationLanguageManager();
                });
            
            services.AddAutoMapper(typeof(Startup));    // для конвертации объектов EF в DTO и обратно
            services.AddControllers().AddNewtonsoftJson(options =>
                // Чтоб в JSON не выгружались циклические ссылки
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddRazorPages();

            services.AddDbContext<LVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LVCContext"), b => b.MigrationsAssembly("LaborVolumeCalculator")));
            
            services.AddScoped<DbContext, LVCContext>();
            services.AddRepositories();

            services.AddScoped<DbSeed>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LaborVolumeCalculator", Version = "v1" });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LaborVolumeCalculator v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            // разрешить крос доменные запросы (CORS)
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

        }
    }
}
