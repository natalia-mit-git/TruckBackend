using Microsoft.AspNetCore.Mvc;
using TruckBackend.Services;
using TruckBackend.Contracts.Requests;
using TruckBackend.Contracts.Responses;

namespace TruckBackend.Controllers;

[ApiController]
[Route("api/trucks")]
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
        try
        {
            var truck = await _truckService.CreateTruck(request);
            return Ok(truck);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{truckId}")]
    public async Task<ActionResult<TruckResponse>> UpdateTruck(int truckId, CreateTruckRequest request)
    {
        try
        {
            var truck = await _truckService.UpdateTruck(truckId, request);
            return Ok(truck);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("{truckId}")]
    public async Task<ActionResult> DeleteTruck(int truckId)
    {
        try
        {
            await _truckService.DeleteTruck(truckId);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{truckId}/loads")]
    public async Task<ActionResult<TruckLoadResponse>> CreateLoad(
        int truckId,
        CreateTruckLoadRequest request)
    {
        try
        {
            var load = await _shippingService.CreateLoad(truckId, request);
            return Ok(load);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}