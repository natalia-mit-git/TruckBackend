using TruckBackend.Services;
using TruckBackend.Contracts.Requests;
using Microsoft.EntityFrameworkCore;
using TruckBackend.Models;
using TruckBackend.Models.Exceptions;

using Xunit;

public class TruckServiceTests
{
    private static TruckService CreateTruckService()
    {
        var options = new DbContextOptionsBuilder<TruckContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new TruckService(new TruckContext(options));
    }

    [Fact]
    public async Task CreateTruck_Should_Return_Created_Truck()
    {
        var service = CreateTruckService();
        var request = new CreateTruckRequest
        {
            Name = "Test Truck"
        };

        var result = await service.CreateTruck(request);

        Assert.NotNull(result);
        Assert.Equal("Test Truck", result.Name);
        Assert.True(result.Id > 0);
    }

    [Fact]
    public async Task DeleteTruck_Should_Remove_Truck()
    {
        var service = CreateTruckService();
        var request = new CreateTruckRequest
        {
            Name = "Test Truck"
        };

        var createdTruck = await service.CreateTruck(request);
        Console.WriteLine("Creating truck for deleteing  with name: " + createdTruck.Name + " and got id: " + createdTruck.Id);

        await service.DeleteTruck(createdTruck.Id);

        await Assert.ThrowsAsync<TruckNotFoundException>(async () =>
        {
            await service.GetTruck(createdTruck.Id);
        });
    }

    [Fact]
    public async Task CreateTruck_Should_Throw_When_Name_Is_Empty()
    {
        var service = CreateTruckService();
        var request = new CreateTruckRequest
        {
            Name = ""
        };
        var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await service.CreateTruck(request);
        });
        Assert.Equal("Name cannot be empty", exception.Message);
    }

    [Fact]
    public async Task UpdateTruck_Should_Throw_When_Name_Is_Empty()
    {
        var service = CreateTruckService();
        var request = new CreateTruckRequest
        {
            Name = ""
        };
        int test_truck_id = 1;
        var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await service.UpdateTruck(test_truck_id, request);
        });
        Assert.Equal("Name cannot be empty", exception.Message);
    }
}
