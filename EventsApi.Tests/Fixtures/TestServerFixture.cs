using IdentityModel.Client;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EventsApi.Tests.Fixtures
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            _testServer = StartTestServer();
            var idpHandler = _testServer.CreateHandler();
            _testServer.Host.Services.GetService<StartupTest>().IdpHandler = idpHandler;
            
            var tokenResponse = GetTokenResponse(idpHandler);
            _testServer.BaseAddress = new Uri("http://localhost:5000");
            Client = _testServer.CreateClient();
            Client.SetBearerToken(tokenResponse.AccessToken);
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }

        private TestServer StartTestServer()
        {
            var builder = WebHost.CreateDefaultBuilder()
                .UseStartup<StartupTest>()
                .UseEnvironment("Test");

            return new TestServer(builder);
        }
        private TokenResponse GetTokenResponse(HttpMessageHandler idpHandler)
        {
            //Gettting the token from the IDP Server
            var disco = new DiscoveryClient("http://localhost:5000", idpHandler);
            var document = disco.GetAsync().Result;
            var tokenClient = new TokenClient(document.TokenEndpoint, "test_client", "client_secret", idpHandler);

            return tokenClient.RequestClientCredentialsAsync().Result;
        }
    }
}