using Microsoft.AspNetCore.Mvc;
using TruckBackend.Services;
using TruckBackend.Contracts.Requests;
using TruckBackend.Contracts.Responses;

namespace TruckBackend.Controllers;

[ApiController]
[Route("api/truck")]
public class TruckController : ControllerBase
{
    private readonly ShippingService _shippingService;
    private readonly TruckService _truckService;
    public TruckController(ShippingService shippingService, TruckService truckService)
    {
        _shippingService = shippingService;
        _truckService = truckService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TruckResponse>>> GetAllTrucks()
    {
        return Ok(await _truckService.GetAllTrucks());
    }

    [HttpGet("{truckId}")]
    public async Task<ActionResult<TruckResponse>> GetTruck(int truckId)
    {
        var truck = await _truckService.GetTruck(truckId);
        return Ok(truck);
    }

    [HttpGet("loads")]
    public async Task<ActionResult<List<TruckLoadResponse>>> GetAllLoads()
    {
        return Ok(await _shippingService.GetAllLoads());
    }

    [HttpGet("{truckId}/loads")]
    public async Task<ActionResult<List<TruckLoadResponse>>> GetLoads(int truckId)
    {
        return Ok(await _shippingService.GetLoads(truckId));
    }

    [HttpPost]
    public async Task<ActionResult<TruckResponse>> CreateTruck(CreateTruckRequest request)
    {
        var truck = await _truckService.CreateTruck(request);
        return Ok(truck);
    }

    [HttpPut("{truckId}")]
    public async Task<ActionResult<TruckResponse>> UpdateTruck(int truckId, CreateTruckRequest request)
    {
        var truck = await _truckService.UpdateTruck(truckId, request);
        return Ok(truck);
    }

    [HttpDelete("{truckId}")]
    public async Task<ActionResult> DeleteTruck(int truckId)
    {
        await _truckService.DeleteTruck(truckId);
        return Ok();
    }

    [HttpPost("{truckId}/loads")]
    public async Task<ActionResult<TruckLoadResponse>> CreateLoad(
        int truckId,
        CreateTruckLoadRequest request)
    {
        var load = await _shippingService.CreateLoad(truckId, request);
        return Ok(load);
    }
}
