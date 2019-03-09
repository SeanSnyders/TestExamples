using App.Metrics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebSocketTest
{
    public class Program
    {
        static IMetricsRoot _metrics;
        static string _serverURL;
        public static void Main(string[] args)
        {
            _serverURL = args[0];
            _metrics = AppMetrics.CreateDefaultBuilder().Build();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
              .UseStartup<Startup>()
              .UseUrls(_serverURL)
              .UseHealthEndpoints()
                        .ConfigureServices((services) =>
                        {
                            services.AddMetrics(_metrics);
                            services.AddMetricsEndpoints();
                        })
            .UseMetricsEndpoints();
    }
}
