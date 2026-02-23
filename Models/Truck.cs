namespace TruckBackend.Models;

// Represents the truck itself
public class Truck
{
    public TruckLoad CreateNewTruckLoad()
    {
        return new TruckLoad();
    }

    public int CalcTotalWeight(int netWeight, int tareWeight)
    {
        return netWeight + tareWeight;
    }
}
