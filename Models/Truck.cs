namespace TruckBackend.Models;

// Represents the truck itself
public class Truck
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<TruckLoad> Loads { get; set; }

    private const int MaxCapacity = 10000;
    private List<TruckLoad> _loads = new();

    public IReadOnlyList<TruckLoad> GetLoads()
    {
        return _loads.AsReadOnly();
    }

    public TruckLoad AddLoad(int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination)
    {
        var load = new TruckLoad(weight, destination);

        if (GetTotalWeight() + weight > MaxCapacity)
            throw new InvalidOperationException("Truck overloaded");

        _loads.Add(load);

        return load;
    }

    public int GetTotalWeight()
    {
        return _loads.Sum(l => l.Weight);
    }
    public int CalcTotalWeight(int netWeight, int tareWeight)
    {
        return netWeight + tareWeight;
    }
}
