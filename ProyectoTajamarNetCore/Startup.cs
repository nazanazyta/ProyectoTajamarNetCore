using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoTajamarNetCore.Data;
using ProyectoTajamarNetCore.Helpers;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            String cadenasql = this.Configuration.GetConnectionString("casasqlnaza");

            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddSingleton<Comparator>();
            //services.AddSingleton<CypherService>();

            services.AddTransient<IRepositoryTheGuauHouse, RepositoryTheGuauHouseSql>();

            services.AddDbContext<GuauHouseContext>(options => options.UseSqlServer(cadenasql));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default"
                    , pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
