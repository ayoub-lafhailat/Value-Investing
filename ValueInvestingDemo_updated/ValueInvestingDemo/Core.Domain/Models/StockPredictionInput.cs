using Core.Domain.Dto;
using Core.Domain.Exceptions;

namespace Core.Domain.Models
{
    public class StockPredictionInput
    {
        public double AdjClose { get; private set; }
        public double Volume { get; private set; }
        public double MarketCap { get; private set; }
        public double PriceToEarningsRatioTtm { get; private set; }
        public double PriceToSalesRatioTtm { get; private set; }
        public double PriceToBookValue { get; private set; }
        public double PriceToFreeCashFlowTtm { get; private set; }
        public double EvEbitda { get; private set; }
        public double EvSales { get; private set; }
        public double BookToMarketValue { get; private set; }
        public double OperatingIncomeEv { get; private set; }
        public double AltmanZScore { get; private set; }

        public StockPredictionInput(
            double adjClose,
            double volume,
            double marketCap,
            double priceToEarningsRatioTtm,
            double priceToSalesRatioTtm,
            double priceToBookValue,
            double priceToFreeCashFlowTtm,
            double evEbitda,
            double evSales,
            double bookToMarketValue,
            double operatingIncomeEv,
            double altmanZScore)
        {
            ValidateFinite(adjClose, nameof(adjClose));
            ValidateFinite(volume, nameof(volume));
            ValidateFinite(marketCap, nameof(marketCap));
            ValidateFinite(priceToEarningsRatioTtm, nameof(priceToEarningsRatioTtm));
            ValidateFinite(priceToSalesRatioTtm, nameof(priceToSalesRatioTtm));
            ValidateFinite(priceToBookValue, nameof(priceToBookValue));
            ValidateFinite(priceToFreeCashFlowTtm, nameof(priceToFreeCashFlowTtm));
            ValidateFinite(evEbitda, nameof(evEbitda));
            ValidateFinite(evSales, nameof(evSales));
            ValidateFinite(bookToMarketValue, nameof(bookToMarketValue));
            ValidateFinite(operatingIncomeEv, nameof(operatingIncomeEv));
            ValidateFinite(altmanZScore, nameof(altmanZScore));

            if (adjClose <= 0)
                throw new PredictionModelException("Adjusted Close must be higher than zero.");

            if (volume < 0)
                throw new PredictionModelException("Volume cannot be negative.");

            if (marketCap < 0)
                throw new PredictionModelException("Market-Cap cannot be negative.");

            AdjClose = adjClose;
            Volume = volume;
            MarketCap = marketCap;
            PriceToEarningsRatioTtm = priceToEarningsRatioTtm;
            PriceToSalesRatioTtm = priceToSalesRatioTtm;
            PriceToBookValue = priceToBookValue;
            PriceToFreeCashFlowTtm = priceToFreeCashFlowTtm;
            EvEbitda = evEbitda;
            EvSales = evSales;
            BookToMarketValue = bookToMarketValue;
            OperatingIncomeEv = operatingIncomeEv;
            AltmanZScore = altmanZScore;
        }

        public StockPredictionInputDTO ToDto()
        {
            return new StockPredictionInputDTO
            {
                AdjClose = AdjClose,
                Volume = Volume,
                MarketCap = MarketCap,
                PriceToEarningsRatioTtm = PriceToEarningsRatioTtm,
                PriceToSalesRatioTtm = PriceToSalesRatioTtm,
                PriceToBookValue = PriceToBookValue,
                PriceToFreeCashFlowTtm = PriceToFreeCashFlowTtm,
                EvEbitda = EvEbitda,
                EvSales = EvSales,
                BookToMarketValue = BookToMarketValue,
                OperatingIncomeEv = OperatingIncomeEv,
                AltmanZScore = AltmanZScore
            };
        }

        private static void ValidateFinite(double value, string fieldName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new PredictionModelException($"{fieldName} must be a valid numeric value.");
        }
    }
}
