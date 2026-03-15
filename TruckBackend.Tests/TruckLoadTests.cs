using TruckBackend.Models;
using Xunit;

public class TruckLoadTests
{
    [Fact]
    public void Constructor_Should_Set_Default_Weight()
    {
        var load = new TruckLoad(TruckLoad.DefaultWeight, "Berlin");

        Assert.Equal(TruckLoad.DefaultWeight, load.Weight);
        Assert.Equal("Berlin", load.Destination);
    }

    [Fact]
    public void Ship_Should_Return_Standard_Message()
    {
        var load = new TruckLoad(1000, "Berlin");

        var result = load.Ship();

        Assert.Equal("Shipping standard load 1000 kg to Berlin", result);
    }
}