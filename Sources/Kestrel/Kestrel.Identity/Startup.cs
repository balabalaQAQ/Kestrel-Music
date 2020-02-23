using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Kestrel.IdentityServer.Models;

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

            // services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            services.AddDbContext<ApplicationDbcontext>(options =>
                options.UseSqlServer(connectionString));


            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbcontext>()
                .AddDefaultTokenProviders();

            services.AddMvc();


            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryApiResources(Config.GetApiResources())
               .AddInMemoryClients(Config.GetClients())

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

               //    options.EnableTokenCleanup = true;//自动清理token
               });

            services.AddAuthentication("Bearer")
             .AddIdentityServerAuthentication(options =>
             {
                  options.Authority = "http://localhost:5001";//授权服务器地址
                  options.RequireHttpsMetadata = false;//是否Https
                  options.ApiName = "music_api";//我们在 Blog.Idp 中配置的资源服务器名
             });
            builder.AddDeveloperSigningCredential();
            services.AddAuthentication();//配置认证服务

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();



            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
