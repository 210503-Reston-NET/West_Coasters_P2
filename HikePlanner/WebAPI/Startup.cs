using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HikePlannerDB")));
            services.AddScoped<IEquipmentRepo, EquipmentRepo>();
            services.AddScoped<IEquipmentBL, EquipmentBL>();
            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<IAddressBL, AddressBL>();
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<ITripRepo, TripRepo>();
            services.AddScoped<ITripBL, TripBL>();
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IPostBL, PostBL>();
            services.AddScoped<IActivityRepo, ActivityRepo>();
            services.AddScoped<IActivityBL, ActivityBL>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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