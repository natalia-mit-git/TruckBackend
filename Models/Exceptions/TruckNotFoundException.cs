namespace TruckBackend.Models.Exceptions
{
    public class TruckNotFoundException : Exception
    {
        public TruckNotFoundException(int truckId) : base(($"Truck with ID {truckId} was not found.")) { }
    }
}