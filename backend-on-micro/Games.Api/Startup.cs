using System.Reflection;
using AutoMapper;
using Games.Api.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Service.Common.Configuration.AppSettings;
using Swashbuckle.AspNetCore.Swagger;

namespace Games.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });

            RegisterDbContext(services);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private void RegisterDbContext(IServiceCollection services)
        {
            var connectionStrings = new ConnectionStrings();
            Configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);

            if (connectionStrings.UseSqLite)
                services.AddDbContext<GamesDbContext>(options => options.UseSqlite(connectionStrings.SqLite,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(GamesDbContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name)));
            else
                services.AddDbContext<GamesDbContext>(options => options.UseSqlServer(
                    connectionStrings.SqlServer,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(GamesDbContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}