namespace Core.Domain.Exceptions
{
    public class PredictionModelException : Exception
    {
        public PredictionModelException(string message) : base(message) { }
        public PredictionModelException(string message, Exception innerException) : base(message, innerException) { }
    }
}
