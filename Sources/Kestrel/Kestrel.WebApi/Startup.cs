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
 
using Kestrel.DataAccess;
using Kestrel.EntityModel.Users;
using Kestrel.ViewModelServices;
using Kestrel.ViewModel.UserVM;
using Kestrel.EntityModel.Music;
using ViewModel.MusicVM;
using Kestrel.ViewModel.MusicVM;
using Microsoft.AspNetCore.Identity;

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

            services.AddDbContext<KestrelDbcontext>(opt =>
            opt.UseSqlServer("Server=localhost;Initial Catalog=KestrelMusicData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));

            services.AddMvcCore().AddAuthorization();


            services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = "http://localhost:5000";
               options.RequireHttpsMetadata = false;
               options.Audience = "music_api";
           });

            // ��ӿ������ݷ��ʷ���
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });



            // ��� DI ����
            //KestrelMusic�û�
            services.AddScoped<IEntityRepository<KestrelMusicUser>, EntityRepository<KestrelMusicUser>>();
            services.AddScoped<IWebAPIModelService<KestrelMusicUser, KestrelMusicUserVM>, WebAPIModelService<KestrelMusicUser, KestrelMusicUserVM>>();

            //����������
            services.AddScoped<IEntityRepository<MusicSingle>, EntityRepository<MusicSingle>>();
            services.AddScoped<IWebAPIModelService<MusicSingle, MusicSingleVM>, WebAPIModelService<MusicSingle, MusicSingleVM>>();

            //�赥
            services.AddScoped<IEntityRepository<SongSheet>, EntityRepository<SongSheet>>();
            services.AddScoped<IWebAPIModelService<SongSheet, SongSheetVM>, WebAPIModelService<SongSheet, SongSheetVM>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ��������������
            app.UseCors("AnyOrigin");

            app.UseDefaultFiles();

            app.UseStaticFiles();

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


