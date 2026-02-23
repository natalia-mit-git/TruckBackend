namespace TruckBackend.Models;

public class ExpressLoad : TruckLoad
{
    public ExpressLoad(int weight = 1000, string destination = "Unknown") : base(weight, destination) { }

    public override string Ship()
    {
        return $"Express shipping {Weight}kg to {Destination}";
    }
}