using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.IO;
using System;

namespace UnitTests
{
    public class TodoTests
    { 
        private readonly TestServer _server; 
        private readonly HttpClient _client;

        public TodoTests() 
        {

            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseContentRoot(@"/home/vagrant/workspace/Kronos-Server/Kronos-Server/Kronos-Server")
                .UseStartup<Kronos_Server.Startup>()
                .UseEnvironment("Developement"));

            _client = _server.CreateClient();  
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task TestGet()
        {
            // Act 
            var response = await _client.GetAsync("api/todo");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);
        }
    }
}
