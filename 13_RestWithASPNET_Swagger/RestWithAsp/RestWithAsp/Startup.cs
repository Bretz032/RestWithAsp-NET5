using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using RestWithAsp.Negocios;
using RestWithAsp.Negocios.Implementations;
using RestWithAsp.Repository;
using RestWithAsp.Repository.Generic;
using RestWithASPNETUdemy.Model.Context;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWithAsp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }



        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Banco
            var connection = Configuration["PostgreeConnection:PostgreeConnectionString"];
            services.AddDbContext<PostgreSQLContext>(options => options.UseNpgsql(connection));



            //Migracoes

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);

            }
            //XML
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();

            //Versionamento
            services.AddApiVersioning();
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Rest API's From 0 to Azure with ASP.NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful developed in course 'Rest API's From 0 to Azure with ASP.NET Core 5 and Docker'",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Fernando Bretz",
                            Url = new Uri("https://fernandobretz.com")
                        }
                    });
            });
            //Injeção de dependência
            services.AddScoped<IPersonNegocios, PersonNegociosImplementation>();

            //Injeção de dependência
            services.AddScoped<IBookNegocios, BookNegociosImplementation>();

            //Injeção de dependência

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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

            app.UseSwagger();

            app.UseSwaggerUI(c=> {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest API's From 0 to Azure with ASP.NET Core 5 and Docker - v1");

            });
            var options = new RewriteOptions();
            options.AddRedirect("^$","swagger");

            app.UseRewriter(options);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new Npgsql.NpgsqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Erro na migracao da Database", ex);
                throw;
            }
        }
    }
}
