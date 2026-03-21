namespace TruckBackend.Models;

public class ExpressLoad : TruckLoad
{
    public ExpressLoad(int truckId, int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination)
        : base(truckId, weight, destination) { }

    public override string Ship()
    {
        return $"Express shipping {Weight} kg to {Destination} by truck {TruckId}";
    }
}