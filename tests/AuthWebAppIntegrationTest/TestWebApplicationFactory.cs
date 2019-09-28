using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace AuthWebAppIntegrationTest
{
    public class TestWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder().ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<TestServerStartup>();
            });
        }
    }
}
