using TruckBackend.Models;
using Xunit;

public class TruckLoadTests
{
    [Fact]
    public void Constructor_Should_Set_Default_Values()
    {
        var load = new TruckLoad(1);

        Assert.Equal(TruckLoad.DefaultWeight, load.Weight);
        Assert.Equal(TruckLoad.DefaultDestination, load.Destination);
    }

    [Fact]
    public void Ship_Should_Return_Standard_Message()
    {
        var load = new TruckLoad(1, TruckLoad.DefaultWeight, "Berlin");

        var result = load.Ship();

        Assert.Equal("Shipping standard load 1000 kg to Berlin by truck 1", result);
    }
}