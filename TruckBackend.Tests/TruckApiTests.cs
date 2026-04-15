using System.Net;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using TruckBackend.Contracts.Responses;

public class TruckApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TruckApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateTruck_Should_Return_200_And_Truck()
    {
        // Arrange
        var request = new
        {
            name = "My Truck"
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/truck", request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<TruckResponse>();

        Assert.NotNull(result);
        Assert.Equal("My Truck", result.Name);
        Assert.True(result.Id > 0);
    }

    [Fact]
    public async Task CreateTruck_Should_Return_400_When_Name_Is_Empty()
    {
        // Arrange
        var request = new
        {
            name = ""
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/truck", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var exception = await response.Content.ReadAsStringAsync();

        Assert.Contains("Name cannot be empty", exception);
    }
}