using TruckBackend.Models;
using Microsoft.EntityFrameworkCore;
using TruckBackend.Contracts.Requests;
using TruckBackend.Contracts.Responses;
using TruckBackend.Models.Exceptions;

namespace TruckBackend.Services;

public class TruckService
{
    private readonly TruckContext _context;

    public TruckService(TruckContext context)
    {
        _context = context;
    }

    public async Task<List<TruckResponse>> GetAllTrucks()
    {
        return await _context.Trucks
            .Select(t => new TruckResponse
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
    }
    public async Task<TruckResponse> GetTruck(int truckId)
    {
        var truck = await _context.Trucks
        .Select(t => new TruckResponse
        {
            Id = t.Id,
            Name = t.Name
        })
        .FirstOrDefaultAsync(t => t.Id == truckId);

        if (truck == null)
            throw new TruckNotFoundException(truckId);
        return truck;
    }

    public async Task<TruckResponse> CreateTruck(CreateTruckRequest dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException("Name cannot be empty");

        var truck = new Truck()
        {
            Name = dto.Name
        };
        _context.Trucks.Add(truck);
        await _context.SaveChangesAsync();

        return new TruckResponse
        {
            Id = truck.Id,
            Name = truck.Name
        };
    }

    public async Task<TruckResponse> UpdateTruck(int truckId, CreateTruckRequest dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException("Name cannot be empty");

        var truck = await _context.Trucks.FindAsync(truckId);
        if (truck == null)
            throw new TruckNotFoundException(truckId);

        truck.Name = dto.Name;
        await _context.SaveChangesAsync();

        return new TruckResponse
        {
            Id = truck.Id,
            Name = truck.Name
        };
    }

    public async Task DeleteTruck(int truckId)
    {
        var truck = await _context.Trucks.FindAsync(truckId);
        if (truck == null)
            throw new TruckNotFoundException(truckId);

        _context.Trucks.Remove(truck);
        await _context.SaveChangesAsync();
    }
}