namespace Core.Domain.Exceptions
{
    public class PredictionServiceException : Exception
    {
        public PredictionServiceException(string message) : base(message) { }
        public PredictionServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
