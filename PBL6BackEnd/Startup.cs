using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PBL6BackEnd.Config;
using PBL6BackEnd.Configure;
using PBL6BackEnd.Extensions;
using PBL6BackEnd.Handlings;
using PBL6BackEnd.Repository;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd
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
            services.ConfigType<PostgresConfig>(Configuration);
            services.ConfigType<TokenConfig>(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PBL6_Back_end", Version = "v1" });
            });
            services.AddCors();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddHttpContextAccessor();
            services.ConfigDatabase();
            services.ConfigSecurity();
            services.MigrateDatabase();
            services.AddMvc(ConfigMvc);
        }

        private void ConfigMvc(MvcOptions options)
        {
            options.Filters.Add(typeof(ValidateModelHandling));
            options.Filters.Add(typeof(HandleExceptionHandling));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PBL6_Back_end v1"));
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMiddleware<TokenProviderMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
