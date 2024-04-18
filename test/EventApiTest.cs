namespace ativa_recife.test;


using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

   public class EventApiTests : IDisposable
    {
        private const string BaseUrl = "https://example.com/api/events";
        private readonly HttpClient _httpClient;

        public EventApiTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task CreateEvent_ReturnsCreated()
        {
            // Arrange
            var requestBody = new
            {
                Title = "Test Event",
                Description = "This is a test event",
                Date = "2024-04-20",
                Hour = "12:00",
                Local = "Test Location"
            };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync(BaseUrl, content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetEvent_ReturnsOk()
        {
            // Arrange & Act
            var response = await _httpClient.GetAsync(BaseUrl);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateEvent_ReturnsNoContent()
        {
            // Arrange
            var requestBody = new
            {
                Title = "Updated Test Event",
                Description = "This is an updated test event",
                Date = "2024-04-20",
                Hour = "13:00",
                Local = "Updated Test Location"
            };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PutAsync($"{BaseUrl}/1", content); 

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteEvent_ReturnsNoContent()
        {
            // Arrange & Act
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/1"); 

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
}