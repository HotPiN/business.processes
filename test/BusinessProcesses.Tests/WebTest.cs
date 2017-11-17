using System.Collections.Generic;
using System.Net.Http;
using BusinessProcesses.Server.Domain.ViewModels;
using BusinessProcesses.Web;
using BusinessProcesses.Web.Start;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace BusinessProcesses.Tests
{
    public class WebTest
    {
        private readonly HttpClient _client;
        
        public WebTest()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }
        
        [Fact]
        public async void GetJobsList()
        {
            var response = await _client.GetAsync("/api/business-processes/GetJobsList");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.True(string.IsNullOrEmpty(responseString), "Can't get jobs list!");

            var jobsList = JsonConvert.DeserializeObject<List<ListJobItem>>(responseString);
            
            Assert.True(jobsList.Count > 0, "Jobs list is empty!");
        }
    }
}