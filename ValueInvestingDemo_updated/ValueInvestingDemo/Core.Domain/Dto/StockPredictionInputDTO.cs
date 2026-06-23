namespace Core.Domain.Dto
{
    public class StockPredictionInputDTO
    {
        public double AdjClose { get; set; }
        public double Volume { get; set; }
        public double MarketCap { get; set; }
        public double PriceToEarningsRatioTtm { get; set; }
        public double PriceToSalesRatioTtm { get; set; }
        public double PriceToBookValue { get; set; }
        public double PriceToFreeCashFlowTtm { get; set; }
        public double EvEbitda { get; set; }
        public double EvSales { get; set; }
        public double BookToMarketValue { get; set; }
        public double OperatingIncomeEv { get; set; }
        public double AltmanZScore { get; set; }
    }
}
