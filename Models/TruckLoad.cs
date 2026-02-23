namespace TruckBackend.Models;

// Represents cargo (data + behavior)
public class TruckLoad
{
    public int Weight { get; private set; }
    public string Destination { get; private set; } = "Unknown";

    public TruckLoad()
    {
        Weight = 1000;
    }

    // Virtual -> polymorphism possible later
    public virtual string Ship()
    {
        return $"Shipping standard load to {Destination}";
    }
}
