using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithAsp.Negocios;
using RestWithAsp.Negocios.Implementations;
using RestWithAsp.Repository;
using RestWithAsp.Repository.Implementations;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithAsp
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
            services.AddControllers();

            //Banco
            var connection = Configuration["PostgreeConnection:PostgreeConnectionString"];
            services.AddDbContext<PostgreSQLContext>(options => options.UseNpgsql(connection));

            //Versionamento
            services.AddApiVersioning();

            //Injeção de dependência

            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

            //Injeção de dependência
            services.AddScoped<IPersonNegocios, PersonNegociosImplementation>();


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
