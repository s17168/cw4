using Cw3WebApplication.DAL;
using Cw3WebApplication.Middleware;
using Cw3WebApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Wyklad5.Services;

namespace Cw3WebApplication
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
            //services.AddScoped<>
            services.AddSingleton<IDbService, MsqlDbService>();
            services.AddTransient<IStudentsDbService, SqlServerStudentDbService>();
            services.AddScoped<LoggingService>();
            services.AddControllers();

            // 1. Add documentation
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Students API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            IStudentsDbService service)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            // 2. Add documentation - add middleware
            app.UseSwagger();
            app.UseSwaggerUI( config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Students App API");
            });

            // Add LoggingMiddleware
            app.UseMiddleware<LoggingMiddleware>();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Headers.ContainsKey("Index")) 
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Musisz podac numer indeksu");
                    return;
                }
                string index = context.Request.Headers["Index"].ToString();
                var student = service.GetStudent(index);
                if (student == null) 
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Student o podanym numerze indeksu nie istnieje");
                    return;
                }

                await next(); // idziemy do kolejnego middleware
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
