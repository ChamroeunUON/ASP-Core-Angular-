using ASP_Angular.Core;
using ASP_Angular.Persistence;
using AutoMapper;
using ASP_Angular.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_Angular
{
    public class Startup {
        public Startup (IConfiguration configuration) {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));
            services.AddScoped<IUnitOfWork, UnitofWork> ();
            services.AddScoped<IVehicleRepository, VehicleRepository> ();

            services.AddAutoMapper ();
            services.AddMvc ();
            // var connection = @"Server=(localdb)\mssqllocaldb;Database=VegaDB;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<VegaDbContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("DefualtConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseWebpackDevMiddleware (new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute (
                    name: "spa-fallback",
                    defaults : new { controller = "Home", action = "Index" });
            });
        }
    }
}