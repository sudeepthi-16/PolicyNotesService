using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PolicyNotesService.Models;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace PolicyNotesService.Tests.Integration
{
    public class NotesApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public NotesApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // POST(return 200)
        [Fact]
        public async Task PostNotes_ShouldReturn201Created()
        {
            var request = new
            {
                policyNumber = "P100",
                note = "Integration test note"
            };

            var response = await _client.PostAsJsonAsync("/notes", request);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        // GET(return 200)
        [Fact]
        public async Task GetNotes_ShouldReturn200Ok()
        {
            var response = await _client.GetAsync("/notes");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // GET with Id (return 200)
        [Fact]
        public async Task GetNotesById_ShouldReturn200Ok_WhenFound()
        {
            var request = new
            {
                policyNumber = "P200",
                note = "Find me"
            };

            var postResponse = await _client.PostAsJsonAsync("/notes", request);
            var created = await postResponse.Content.ReadFromJsonAsync<PolicyNote>();


            var getResponse = await _client.GetAsync($"/notes/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
        }

        // GET with Id (return 404)
        [Fact]
        public async Task GetNotesById_ShouldReturn404NotFound_WhenMissing()
        {
            var response = await _client.GetAsync("/notes/99999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}


//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.Hosting;
////using Microsoft.VisualStudio.TestPlatform.TestHost;
//using PolicyNotesService.Models;
//using System.IO;
//using System.Net;
//using System.Net.Http.Json;
//using Xunit;

//namespace PolicyNotesService.Tests.Integration
//{
//    // Custom factory to fix testhost.deps.json issue
//    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
//    {
//        protected override IHost CreateHost(IHostBuilder builder)
//        {
//            // Force WebApplicationFactory to use the actual application output folder
//            var projectDir = Directory.GetCurrentDirectory();

//            // Navigate to the API project bin folder manually
//            var apiOutputPath = Path.GetFullPath(
//                Path.Combine(projectDir, @"..\..\PolicyNotesService\bin\Debug\net8.0")
//            );

//            builder.UseContentRoot(apiOutputPath);

//            return base.CreateHost(builder);
//        }
//    }

//    public class NotesApiTests : IClassFixture<CustomWebApplicationFactory>
//    {
//        private readonly HttpClient _client;

//        public NotesApiTests(CustomWebApplicationFactory factory)
//        {
//            _client = factory.CreateClient();
//        }

//        // POST /notes → 201 Created
//        [Fact]
//        public async Task PostNotes_ShouldReturn201Created()
//        {
//            var request = new
//            {
//                policyNumber = "P100",
//                note = "Integration test note"
//            };

//            var response = await _client.PostAsJsonAsync("/notes", request);

//            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
//        }

//        // GET /notes → 200 OK
//        [Fact]
//        public async Task GetNotes_ShouldReturn200Ok()
//        {
//            var response = await _client.GetAsync("/notes");

//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//        }

//        // GET /notes/{id} → 200 OK (when found)
//        [Fact]
//        public async Task GetNotesById_ShouldReturn200Ok_WhenFound()
//        {
//            var request = new
//            {
//                policyNumber = "P200",
//                note = "Find me"
//            };

//            var postResponse = await _client.PostAsJsonAsync("/notes", request);
//            var created = await postResponse.Content.ReadFromJsonAsync<PolicyNote>();

//            var getResponse = await _client.GetAsync($"/notes/{created.Id}");

//            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
//        }

//        // GET /notes/{id} → 404 Not Found
//        [Fact]
//        public async Task GetNotesById_ShouldReturn404NotFound_WhenMissing()
//        {
//            var response = await _client.GetAsync("/notes/99999");

//            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//        }
//    }
//}

