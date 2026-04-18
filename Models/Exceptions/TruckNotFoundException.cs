namespace TruckBackend.Models.Exceptions
{
    public class TruckNotFoundException : Exception
    {
        public string UserMessage { get; }
        public TruckNotFoundException(int truckId) : base(($"Truck with ID {truckId} was not found."))
        {
            UserMessage = $"Truck not found.";
        }
    }
}