using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDoc(t =>
            {
                t.ApiDocPath = "apidoc";//api访问路径
                t.Title = "爆点";//文档名称
            }); 
        }
    }
}
