using TruckBackend.Models;

namespace TruckBackend.Services;

public class ShippingService
{
    private readonly Truck _truck = new Truck();

    public TruckLoad CreateLoad(int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination)
    {
        return _truck.AddLoad(weight, destination);
    }

    public string ShipLoad(TruckLoad load)
    {
        return load.Ship();
    }
}
