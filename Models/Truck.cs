namespace TruckBackend.Models;

// Represents the truck itself
public class Truck
{
    private List<TruckLoad> _loads = new();

    public IReadOnlyList<TruckLoad> GetLoads()
    {
        return _loads.AsReadOnly();
    }

    public TruckLoad AddLoad(int weight = TruckLoad.DefaultWeight, string destination = TruckLoad.DefaultDestination)
    {
        var load = new TruckLoad(weight, destination);

        if (GetTotalWeight() + weight > 10000)
            throw new Exception("Truck overloaded");

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
