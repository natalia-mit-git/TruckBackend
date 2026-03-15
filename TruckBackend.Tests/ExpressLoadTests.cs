using TruckBackend.Models;
using Xunit;

public class ExpressLoadTests
{
    [Fact]
    public void Constructor_Should_Set_Default_Weight()
    {
        var load = new ExpressLoad(ExpressLoad.DefaultWeight, "Berlin");

        Assert.Equal(TruckLoad.DefaultWeight, load.Weight);
        Assert.Equal("Berlin", load.Destination);
    }

    [Fact]
    public void Ship_Should_Return_Standard_Message()
    {
        var load = new ExpressLoad(300, "Berlin");

        var result = load.Ship();

        Assert.Equal("Express shipping 300 kg to Berlin", result);
    }
}