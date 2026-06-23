using Core.Domain.Dto;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Moq;
using Xunit;

namespace UnitTest
{
    public class PredictionServiceUnitTest
    {
        [Fact]
        public void PredictFutureAdjClose_ReturnsPredictionFromRepository()
        {
            var repositoryMock = new Mock<IPredictionRepository>();
            repositoryMock
                .Setup(repository => repository.PredictFutureAdjClose(It.IsAny<StockPredictionInputDTO>()))
                .Returns(new StockPredictionResultDTO
                {
                    PredictedFutureAdjClose = 125.50,
                    IsFallbackPrediction = false,
                    Warning = null
                });

            var predictionService = new PredictionService(repositoryMock.Object);
            var input = new StockPredictionInput(100, 1000, 1000000, 15, 2, 3, 12, 8, 1, 0.3, 0.05, 2.5);

            var result = predictionService.PredictFutureAdjClose(input);

            Assert.Equal(125.50, result.PredictedFutureAdjClose);
            Assert.False(result.IsFallbackPrediction);
        }
    }
}
