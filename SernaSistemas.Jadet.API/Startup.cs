using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SernaSistemas.Jadet.BLogic;
using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.Repository;

namespace SernaSistemas.Jadet.API
{
    public class Startup
    {

        private readonly IBLAdministracion iBLAdministracion;
        private readonly IDbAdministracionContext dbAdministracionContext;
        private readonly BDJadetContext entities;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            entities = new BDJadetContext(
                //Configuration.GetConnectionString("BDJadetConnection")
                );
            dbAdministracionContext = new DbAdministracionContext(entities);
            iBLAdministracion = new BLAdministracion(dbAdministracionContext);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Add(new ServiceDescriptor(typeof(IBLAdministracion), iBLAdministracion));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SernaSistemas.Jadet.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SernaSistemas.Jadet.API v1"));
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
