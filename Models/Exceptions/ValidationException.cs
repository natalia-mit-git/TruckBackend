namespace TruckBackend.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public string UserMessage { get; }

        public ValidationException(string message) : base(message)
        {
            UserMessage = $"Validation error.";
        }
    }
}