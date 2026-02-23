using TruckBackend.Models;

namespace TruckBackend.Services;

public class ShippingService
{
    private readonly Truck _truck = new Truck();

    public TruckLoad CreateLoad(string destination)
    {
        var load = _truck.CreateNewTruckLoad();
        load.Destination = destination;
        return load;
    }

    public string ShipLoad(TruckLoad load)
    {
        return load.Ship();
    }
}
