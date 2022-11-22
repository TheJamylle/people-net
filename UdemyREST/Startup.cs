using Microsoft.EntityFrameworkCore;
using UdemyREST.Model.Context;
using UdemyREST.Business;
using UdemyREST.Business.Implementations;
using UdemyREST.Repository;
using UdemyREST.Repository.Implementations;

namespace UdemyREST
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

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            var serverVersion =  new MySqlServerVersion(new Version(8, 0, 27));
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, serverVersion));

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
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
