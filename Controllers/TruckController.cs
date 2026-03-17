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
    public ActionResult<List<TruckLoad>> GetLoads()
    {
        return Ok(_shippingService.GetLoads());
    }

    [HttpPost("create")]
    public ActionResult<CreateLoadResponse> CreateLoad(CreateLoadRequest request)
    {
        var load = _shippingService.CreateLoad(request.Weight, request.Destination);

        return Ok(new CreateLoadResponse(load.Weight, load.Destination));
    }

    [HttpPost("ship")]
    public ActionResult<string> ShipLoad(ShipLoadRequest request)
    {
        var load = new TruckLoad(request.Weight, request.Destination);

        return Ok(_shippingService.ShipLoad(load));
    }
}

public record CreateLoadRequest(int Weight, string Destination);

public record ShipLoadRequest(int Weight, string Destination);

public record CreateLoadResponse(int Weight, string Destination);
