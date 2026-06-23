using Core.Domain.Exceptions;
using Core.Domain.Models;
using Xunit;

namespace UnitTest
{
    public class StockPredictionInputUnitTest
    {
        [Fact]
        public void Constructor_WithValidValues_CreatesModel()
        {
            var input = new StockPredictionInput(100, 1000, 1000000, 15, 2, 3, 12, 8, 1, 0.3, 0.05, 2.5);

            Assert.Equal(100, input.AdjClose);
            Assert.Equal(1000, input.Volume);
        }

        [Fact]
        public void Constructor_WithInvalidAdjClose_ThrowsPredictionModelException()
        {
            Assert.Throws<PredictionModelException>(() =>
                new StockPredictionInput(0, 1000, 1000000, 15, 2, 3, 12, 8, 1, 0.3, 0.05, 2.5));
        }
    }
}
