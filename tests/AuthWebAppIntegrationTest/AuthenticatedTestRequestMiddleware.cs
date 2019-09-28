using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthWebAppIntegrationTest
{
    public class AuthenticatedTestRequestMiddleware
    {
        private const string AuthenticationType = "TestAuthenticationType";

        public const string TestingHeader = "X-Integration-Testing";
        public const string TestingHeaderValue = "Pass-Auth";

        public const string FakeLoginIdHeaderKey = "X-Test-LoginId";

        private readonly RequestDelegate _next;


        public AuthenticatedTestRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains(TestingHeader) &&
                context.Request.Headers[TestingHeader].First().Equals(TestingHeaderValue))
            {
                if (context.Request.Headers.Keys.Contains(FakeLoginIdHeaderKey))
                {
                    var loginId = context.Request.Headers[FakeLoginIdHeaderKey].First();

                    ClaimsIdentity identity = new ClaimsIdentity(AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, loginId));

                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    context.User = claimsPrincipal;
                }
            }

            await _next(context);
        }
    }
}
