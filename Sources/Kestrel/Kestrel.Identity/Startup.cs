using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kestrel.ORM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kestrel.Identity
{
    public class Startup
    {
        private string connectionString = "Server=localhost;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            
            services.AddDbContext<ApplicationDbcontext>(options =>
                options.UseSqlServer(connectionString));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbcontext>()
                .AddDefaultTokenProviders();

          


               var builder = services.AddIdentityServer()
               .AddAspNetIdentity<ApplicationUser>()

               //clients,resources
               .AddConfigurationStore(options =>
               {
                   options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly("Kestrel.Identity"));
               })
               //codes,tokens,consents
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                      sql => sql.MigrationsAssembly("Kestrel.Identity"));

                   options.EnableTokenCleanup = true;//�Զ�����token
               });

           
            services.AddAuthentication();//������֤����

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            app.UseRouting();
          
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
          
            
        }
    }
}
