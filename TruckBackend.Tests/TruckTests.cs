using TruckBackend.Models;
using Xunit;

public class TruckTests
{
    [Fact]
    public void AddLoad_Should_Create_Load()
    {
        var truck = new Truck();

        var load = truck.AddLoad(destination: "Munich");

        Assert.Equal("Munich", load.Destination);

    }

    [Fact]
    public void AddLoad_Should_Throw_Exception_When_Overloaded()
    {
        var truck = new Truck();

        truck.AddLoad(weight: 9000, destination: "Munich");

        Assert.Throws<InvalidOperationException>(() => truck.AddLoad(weight: 2000, destination: "Berlin"));
    }

    [Fact]
    public void GetLoads_Should_Return_All_Loads()
    {
        var truck = new Truck();
        truck.AddLoad(weight: 1000, destination: "Munich");
        truck.AddLoad(weight: 2000, destination: "Berlin");

        var loads = truck.Loads;

        Assert.Equal(2, loads.Count);

        var munichLoad = loads.SingleOrDefault(l => l.Destination == "Munich");
        Assert.NotNull(munichLoad);
        Assert.Equal(1000, munichLoad.Weight);

        var berlinLoad = loads.SingleOrDefault(l => l.Destination == "Berlin");
        Assert.NotNull(berlinLoad);
        Assert.Equal(2000, berlinLoad.Weight);
    }

    [Fact]
    public void GetTotalWeight_Should_Return_Correct_Value()
    {
        var truck = new Truck();

        truck.AddLoad(weight: 1000, destination: "Munich");
        truck.AddLoad(weight: 2000, destination: "Berlin");

        Assert.Equal(3000, truck.GetTotalWeight());
    }

}
