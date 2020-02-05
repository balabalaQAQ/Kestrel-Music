using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
 
namespace Kestrel
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

      
            // 添加数据库访问上下文中间件
            services.AddDbContext<KestrelDbcontext>(opt => opt.UseSqlServer("Server=localhost;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));

            //   添加 DI 配置
            //积分商城
            services.AddScoped<IEntityRepository<Commodity>, EntityRepository<Commodity>>();
            services.AddScoped<IWebAPIModelService<Commodity, CommodityVM>, WebAPIModelService<Commodity, CommodityVM>>();

            services.AddControllers();
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
