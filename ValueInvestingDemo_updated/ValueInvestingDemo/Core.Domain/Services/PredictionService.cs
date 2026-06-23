using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Domain.Models;

namespace Core.Domain.Services
{
    public class PredictionService
    {
        private readonly IPredictionRepository _predictionRepository;

        public PredictionService(IPredictionRepository predictionRepository)
        {
            _predictionRepository = predictionRepository;
        }

        public StockPredictionResult PredictFutureAdjClose(StockPredictionInput input)
        {
            try
            {
                var resultDto = _predictionRepository.PredictFutureAdjClose(input.ToDto());
                return new StockPredictionResult(resultDto);
            }
            catch (PredictionRepositoryException exception)
            {
                throw new PredictionServiceException("Error while retrieving the prediction from the model infrastructure.", exception);
            }
        }

        public List<StockPredictionInput> GetExampleInputs()
        {
            return new List<StockPredictionInput>
            {
                new StockPredictionInput(100.00, 2500000, 45000000000, 18.5, 3.2, 4.1, 22.0, 12.4, 2.9, 0.24, 0.07, 3.1),
                new StockPredictionInput(42.75, 890000, 7800000000, 11.2, 1.6, 1.8, 9.7, 7.5, 1.2, 0.55, 0.09, 2.6),
                new StockPredictionInput(186.40, 4200000, 120000000000, 28.4, 6.8, 9.3, 35.5, 18.2, 5.1, 0.11, 0.05, 4.4)
            };
        }
    }
}
