using Eventos.IO.Services.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Eventos.IO.Tests.Api.IntegrationTests
{
    public class Environment
    {
        public static TestServer Server { get; set; }
        public static HttpClient Client { get; set; }

        public static void CriarServidor()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseUrls("http://localhost:8285")
                .UseStartup<StartupTests>();

            Server = new TestServer(webHostBuilder);

            Client = Server.CreateClient();
        }
    }
}
