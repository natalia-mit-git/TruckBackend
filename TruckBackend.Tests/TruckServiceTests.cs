using TruckBackend.Services;
using TruckBackend.Contracts.Requests;
using Microsoft.EntityFrameworkCore;
using TruckBackend.Models;
using TruckBackend.Models.Exceptions;

using Xunit;

public class TruckServiceTests
{
    [Fact]
    public async Task CreateTruck_Should_Return_Created_Truck()
    {
        var options = new DbContextOptionsBuilder<TruckContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using (var context = new TruckContext(options))
        {
            var service = new TruckService(context);

            var request = new CreateTruckRequest
            {
                Name = "Test Truck"
            };

            var result = await service.CreateTruck(request);

            Assert.NotNull(result);
            Assert.Equal("Test Truck", result.Name);
            Assert.True(result.Id > 0);
        }
    }

    [Fact]
    public async Task DeleteTruck_Should_Remove_Truck()
    {
        var options = new DbContextOptionsBuilder<TruckContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using (var context = new TruckContext(options))
        {
            var service = new TruckService(context);

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
    }
}