using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using TruckBackend.Models;

namespace TruckBackend.Tests;

public class TruckApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<TruckContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<TruckContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });
        });
    }
}