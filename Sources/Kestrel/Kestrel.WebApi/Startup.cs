using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kestrel.ORM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Kestrel._Identity;

namespace Kestrel.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.UseSqlServer
        public void ConfigureServices(IServiceCollection services)
        {
         
            var builder = services.AddIdentityServer()
             .AddTestUsers(Config.User)
            .AddInMemoryApiResources(Config.GetApis())
            .AddInMemoryClients(Config.GetClients());


            builder.AddDeveloperSigningCredential();//Text专用
            services.AddDbContext<KestrelDbcontext>(opt => opt.UseSqlServer("Server=localhost;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));
            services.AddMvcCore().AddAuthorization();
            //   添加 DI 配置

            services.AddControllers();

            services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = "http://localhost:5000";
               options.RequireHttpsMetadata = false;    

               options.Audience = "music_api";
           });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();//认证
            app.UseAuthorization();//授权

        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
             
            });
        }
    }
}
