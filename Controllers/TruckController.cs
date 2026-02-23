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

    // GET api/truck/create?destination=Berlin
    [HttpGet("create")]
    public ActionResult<TruckLoad> CreateLoad(string destination)
    {
        var load = _shippingService.CreateLoad(destination);
        return Ok(load);
    }

    // POST api/truck/ship
    [HttpPost("ship")]
    public ActionResult<string> ShipLoad([FromBody] TruckLoad load)
    {
        var result = _shippingService.ShipLoad(load);
        return Ok(result);
    }
}