using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TeleBook.Domain.Interfaces;
using TeleBook.Infrastructure;
using TeleBook.Infrastructure.Implementations;

namespace TeleBook.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddHttpContextAccessor();
            
            services.AddControllers();
            
            services.AddAutoMapper(typeof(Startup));
            
            services.AddDbContext<TeleBookDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TeleBook")));
            
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<TeleBookDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<TeleBookDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            
            services.AddCors(options =>
            {
                options.AddPolicy("allowall", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });  
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Tele Book APIs", 
                    Version = "v1",
                    Description =  "Tele Book APIs description"
                });
                
            });
            
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,TeleBookDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            dbContext.Database.Migrate();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            
            app.UseCors("allowall");
            
            app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/swagger.json"; });

            app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "api-docs";
                    options.DocumentTitle = "Tutor Student APIs";
                    options.SwaggerEndpoint("v1/swagger.json", "Tele Book definition");
                    options.OAuthClientId("swaggerapiui");
                    options.OAuthAppName("Swagger API UI");
                }
            );
            
            
            app.UseRouting();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}