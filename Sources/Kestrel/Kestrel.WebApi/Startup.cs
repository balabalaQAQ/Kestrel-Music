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
            services.AddDbContext<KestrelDbcontext>(opt => opt.UseSqlServer("Server=localhost;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));
            services.AddMvcCore().AddAuthorization();
            //   ���� DI ����

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

            app.UseAuthentication();//��֤
            app.UseAuthorization();//��Ȩ



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
             
            });
        }
    }
}
