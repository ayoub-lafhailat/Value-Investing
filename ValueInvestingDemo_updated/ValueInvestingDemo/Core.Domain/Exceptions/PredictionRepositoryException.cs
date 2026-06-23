namespace Core.Domain.Exceptions
{
    public class PredictionRepositoryException : Exception
    {
        public PredictionRepositoryException(string message) : base(message) { }
        public PredictionRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
