using Core.Domain.Dto;

namespace Core.Domain.Models
{
    public class StockPredictionResult
    {
        public double PredictedFutureAdjClose { get; private set; }
        public bool IsFallbackPrediction { get; private set; }
        public string? Warning { get; private set; }

        public StockPredictionResult(double predictedFutureAdjClose, bool isFallbackPrediction, string? warning)
        {
            PredictedFutureAdjClose = predictedFutureAdjClose;
            IsFallbackPrediction = isFallbackPrediction;
            Warning = warning;
        }

        public StockPredictionResult(StockPredictionResultDTO dto)
        {
            PredictedFutureAdjClose = dto.PredictedFutureAdjClose;
            IsFallbackPrediction = dto.IsFallbackPrediction;
            Warning = dto.Warning;
        }
    }
}
