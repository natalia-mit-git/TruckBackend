namespace TruckBackend.Models;

// Represents cargo (data + behavior)
public class TruckLoad
{
    public int Weight { get; private set; }
    public string Destination { get; private set; }

    public TruckLoad(int weight = 1000, string destination = "Unknown")
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
