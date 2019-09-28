using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace AuthWebAppIntegrationTest
{
    public class TestServerStartup : AuthWebApp.Startup
    {
        public TestServerStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureAdditionalMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
        }

        protected override void ConfigureHttps(IApplicationBuilder app)
        {
        }
    }
}
