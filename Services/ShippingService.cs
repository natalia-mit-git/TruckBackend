using TruckBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace TruckBackend.Services;

public class ShippingService
{
    private readonly TruckContext _context;

    public ShippingService(TruckContext context)
    {
        _context = context;
    }

    public async Task<TruckLoad> CreateLoad(int truckId, int weight, string destination)
    {
        var truck = await _context.Trucks
            .Include(t => t.Loads)
            .FirstOrDefaultAsync(t => t.Id == truckId);
        if (truck == null)
        {
            throw new InvalidOperationException("Truck not found");
        }

        var load = truck.AddLoad(weight, destination);

        await _context.SaveChangesAsync();

        return load;
    }
    public async Task<List<TruckLoad>> GetLoads()
    {
        return await _context.TruckLoads.ToListAsync();
    }
}
