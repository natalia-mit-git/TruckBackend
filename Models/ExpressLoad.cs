namespace TruckBackend.Models;

public class ExpressLoad : TruckLoad
{
    public ExpressLoad(int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination) : base(weight, destination) { }

    public override string Ship()
    {
        return $"Express shipping {Weight}kg to {Destination}";
    }
}