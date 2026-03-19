namespace TruckBackend.Contracts.Responses;

public class TruckLoadResponse
{
    public int Id { get; set; }
    public int Weight { get; set; }
    public string Destination { get; set; } = string.Empty;
}