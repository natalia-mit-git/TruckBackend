using Microsoft.AspNetCore.Mvc;
using TruckBackend.Services;
using TruckBackend.Contracts.Requests;
using TruckBackend.Contracts.Responses;

namespace TruckBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TruckController : ControllerBase
{
    private readonly ShippingService _shippingService;

    public TruckController(ShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    [HttpGet("all_loads")]
    public async Task<ActionResult<List<TruckLoadResponse>>> GetAllLoads()
    {
        return Ok(await _shippingService.GetAllLoads());
    }

    [HttpGet("{truckId}/loads")]
    public async Task<ActionResult<List<TruckLoadResponse>>> GetLoads(int truckId)
    {
        return Ok(await _shippingService.GetLoads(truckId));
    }

    [HttpPost("trucks/{truckId}/loads")]
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