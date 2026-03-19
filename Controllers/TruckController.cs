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

    [HttpGet("loads")]
    public async Task<ActionResult<List<TruckLoadResponse>>> GetLoads()
    {
        return Ok(await _shippingService.GetLoads());
    }

    [HttpPost("trucks/{truckId}/loads")]
    public async Task<ActionResult<TruckLoadResponse>> CreateLoad(
        int truckId,
        CreateTruckLoadRequest request)
    {
        var load = await _shippingService.CreateLoad(truckId, request);
        return Ok(load);
    }
}