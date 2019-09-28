using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AuthWebAppIntegrationTest
{
    public class TestWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                       .UseStartup<TestServerStartup>(); //UseStartup have no relations with type parameter TEntryPoint, use our all new TestServerStartup here.
        }
    }
}
