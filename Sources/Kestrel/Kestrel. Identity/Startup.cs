using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Kestrel._Identity
{
    public class Startup
    {
        private string connectionString = @"Data Source=S4F91FY1JZBZ19H\SA;Initial Catalog=Kestrel.Identity;User ID=sa;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
         
        }
        public IConfiguration   Configuration{get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddControllers();

            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString));

        

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();


            var builder = services.AddIdentityServer(options =>
            {
              
            })
               .AddAspNetIdentity<IdentityUser>()
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
                   options.EnableTokenCleanup = true;//自动清理token
               });

           services.AddAuthentication();//配置认证服务


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          app.UseIdentityServer();
        //    app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
