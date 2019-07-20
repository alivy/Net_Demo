using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WebAppCore
{
    public class Startup
    {
        //读取配置文件
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //此方法由运行时调用。使用此方法将服务添加到容器。
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // 此lambda确定对于给定请求是否需要用户同意非必要cookie。
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddApiDoc(t =>
            {
                t.ApiDocPath = "apidoc";//api访问路径
                t.Title = "爆点";//文档名称
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "爆点API接口文档",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "鸟窝",
                        Email = "topbrids@gmail.com",
                        Url = "http://www.cnblogs.com/gdsblog"
                    }
                });

                //c.IncludeXmlComments(XmlCommentsFilePath);
                //c.IncludeXmlComments(XmlDomianCommentsFilePath);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
      
     
        //此方法由运行时调用。使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Run(x => x.Response.WriteAsync(""));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
            //routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "爆点");
            });
        }

       
    }
}
