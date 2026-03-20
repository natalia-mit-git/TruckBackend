using TruckBackend.Models;
using Microsoft.EntityFrameworkCore;
using TruckBackend.Contracts.Requests;
using TruckBackend.Contracts.Responses;

namespace TruckBackend.Services;

public class ShippingService
{
    private readonly TruckContext _context;

    public ShippingService(TruckContext context)
    {
        _context = context;
    }

    public async Task<TruckLoadResponse> CreateLoad(int truckId, CreateTruckLoadRequest dto)
    {
        var truck = await _context.Trucks
            .Include(t => t.Loads)
            .FirstOrDefaultAsync(t => t.Id == truckId);

        if (truck == null)
            throw new KeyNotFoundException($"Truck with id {truckId} not found");

        var load = truck.AddLoad(dto.Weight, dto.Destination);
        Console.WriteLine($"TruckId in load: {load.TruckId}");

        await _context.SaveChangesAsync();

        return new TruckLoadResponse
        {
            Id = load.Id,
            Weight = load.Weight,
            Destination = load.Destination
        };
    }

    public async Task<List<TruckLoadResponse>> GetLoads()
    {
        return await _context.TruckLoads
            .Select(l => new TruckLoadResponse
            {
                Id = l.Id,
                Weight = l.Weight,
                Destination = l.Destination
            })
            .ToListAsync();
    }

}
