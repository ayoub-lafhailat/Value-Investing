namespace Core.Domain.Dto
{
    public class StockPredictionResultDTO
    {
        public double PredictedFutureAdjClose { get; set; }
        public bool IsFallbackPrediction { get; set; }
        public string? Warning { get; set; }
    }
}
