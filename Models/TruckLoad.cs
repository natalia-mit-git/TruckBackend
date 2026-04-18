namespace TruckBackend.Models;

// Represents cargo (data + behavior)
public class TruckLoad
{
    public const int DefaultWeight = 1000;
    public const string DefaultDestination = "Unknown";

    public int Id { get; set; }
    public int Weight { get; set; } = DefaultWeight;
    public string Destination { get; set; } = DefaultDestination;

    public int TruckId { get; set; }
    public Truck? Truck { get; set; }
    public TruckLoad(int truckId, int weight = DefaultWeight, string destination = DefaultDestination)
    {
        TruckId = truckId;
        Weight = weight;
        Destination = destination;
    }

    // Default shipping behavior for standard loads
    public virtual string Ship()
    {
        return $"Shipping standard load {Weight} kg to {Destination} by truck {TruckId}";
    }
}
