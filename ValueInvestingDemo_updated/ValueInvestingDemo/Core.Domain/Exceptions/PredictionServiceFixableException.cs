namespace Core.Domain.Exceptions
{
    public class PredictionServiceFixableException : Exception
    {
        public PredictionServiceFixableException(string message) : base(message) { }
        public PredictionServiceFixableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
