using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Research_GRPC;

namespace Research_GRPC
{
    // https://www.youtube.com/watch?v=QyxCX2GYHxk&ab_channel=IAmTimCorey
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigManager().GetConfiguration();
            // сюда конфиг
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel().UseUrls(config["HostURL"]);
                });
        }
    }
}
