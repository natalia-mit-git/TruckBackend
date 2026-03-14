namespace TruckBackend.Models;

// Represents cargo (data + behavior)
public class TruckLoad
{
    public const int DefaultWeight = 1000;
    public const string DefaultDestination = "Unknown";
    public int Weight { get; private set; }
    public string Destination { get; private set; }

    public TruckLoad(int weight, string destination)
    {
        Weight = weight;
        Destination = destination;
    }

    // Virtual -> polymorphism possible later
    public virtual string Ship()
    {
        return $"Shipping standard load to {Destination}";
    }
}
