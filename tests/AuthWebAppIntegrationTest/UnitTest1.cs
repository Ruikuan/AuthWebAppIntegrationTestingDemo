using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AuthWebAppIntegrationTest
{
    public class UnitTest1 : IClassFixture<TestWebApplicationFactory<AuthWebApp.Startup>> // use SUT's Startup here, for it helps to set root path.
    {
        private readonly TestWebApplicationFactory<AuthWebApp.Startup> _factory;

        public UnitTest1(TestWebApplicationFactory<AuthWebApp.Startup> factory) => _factory = factory;

        [Fact]
        public async Task Visit_Index_Success()
        {
            // Arrange
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

        }

        [Fact]
        public async Task Visit_Privacy_Success()
        {
            // Arrange
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.FakeLoginIdHeaderKey, "fakeUser");

            // Act
            var response = await client.GetAsync("/Home/Privacy");
            
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
