using Core.Domain.Dto;

namespace Core.Domain.Interfaces
{
    public interface IPredictionRepository
    {
        StockPredictionResultDTO PredictFutureAdjClose(StockPredictionInputDTO input);
    }
}
