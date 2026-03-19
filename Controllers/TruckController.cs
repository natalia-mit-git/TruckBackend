using Microsoft.AspNetCore.Mvc;
using TruckBackend.Models;
using TruckBackend.Services;

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

    [HttpGet("loads")]
    public async Task<ActionResult<List<TruckLoad>>> GetLoads()
    {
        return Ok(await _shippingService.GetLoads());
    }

    [HttpPost("trucks/{truckId}/loads")]
    public async Task<ActionResult<CreateLoadResponse>> CreateLoad(
         int truckId,
         CreateLoadRequest request)
    {
        var load = await _shippingService.CreateLoad(truckId, request.Weight, request.Destination);

        return Ok(new CreateLoadResponse(load.Weight, load.Destination));
    }
}

public record CreateLoadRequest(int Weight, string Destination);

public record ShipLoadRequest(int Weight, string Destination);

public record CreateLoadResponse(int Weight, string Destination);
