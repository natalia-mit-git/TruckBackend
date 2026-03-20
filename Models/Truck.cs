namespace TruckBackend.Models;

// Represents the truck itself
public class Truck
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<TruckLoad> Loads { get; set; } = new List<TruckLoad>();

    private const int MaxCapacity = 10000;

    public TruckLoad AddLoad(int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination)
    {
        if (GetTotalWeight() + weight > MaxCapacity)
            throw new InvalidOperationException("Truck overloaded");

        var load = new TruckLoad(weight, destination);

        Loads.Add(load);

        return load;
    }

    public int GetTotalWeight()
    {
        return Loads.Sum(l => l.Weight);
    }
    public int CalcTotalWeight(int netWeight, int tareWeight)
    {
        return netWeight + tareWeight;
    }
}
