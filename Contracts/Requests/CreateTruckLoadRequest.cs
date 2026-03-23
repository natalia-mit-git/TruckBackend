namespace TruckBackend.Contracts.Requests;

public class CreateTruckLoadRequest
{
    public int Weight { get; set; }
    public string Destination { get; set; } = string.Empty;
}