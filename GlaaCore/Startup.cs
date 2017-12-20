using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlaaCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace GlaaCore
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
            var usr = Configuration["DB_USER"];
            var pwd = Configuration["DB_PASS"];
            var cs = $"Data Source=glaa-test-db-service.glaa-dev.svc.cluster.local,1433;Initial Catalog=GLAA_Core;Integrated Security=False;User Id={usr};Password={pwd};MultipleActiveResultSets=True";
            services.AddMvc();
            services.AddDbContext<GlaaContext>(opt => opt.UseSqlServer(cs));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables(); 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                GlaaContextInitializer.Initialize(serviceScope.ServiceProvider.GetService<GlaaContext>());
            }
        }
    }
}
