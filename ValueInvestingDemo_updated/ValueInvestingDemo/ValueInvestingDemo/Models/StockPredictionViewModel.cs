using System.ComponentModel.DataAnnotations;
using Core.Domain.Models;

namespace ValueInvestingDemo.Models
{
    public class StockPredictionViewModel
    {
        [Display(Name = "Adjusted Close")]
        [Required(ErrorMessage = "Adjusted Close is required.")]
        public double? AdjClose { get; set; }

        [Display(Name = "Volume")]
        [Required(ErrorMessage = "Volume is required.")]
        public double? Volume { get; set; }

        [Display(Name = "Market-Cap")]
        [Required(ErrorMessage = "Market-Cap is required.")]
        public double? MarketCap { get; set; }

        [Display(Name = "Price to Earnings Ratio (ttm)")]
        [Required(ErrorMessage = "Price to Earnings Ratio is required.")]
        public double? PriceToEarningsRatioTtm { get; set; }

        [Display(Name = "Price to Sales Ratio (ttm)")]
        [Required(ErrorMessage = "Price to Sales Ratio is required.")]
        public double? PriceToSalesRatioTtm { get; set; }

        [Display(Name = "Price to Book Value")]
        [Required(ErrorMessage = "Price to Book Value is required.")]
        public double? PriceToBookValue { get; set; }

        [Display(Name = "Price to Free Cash Flow (ttm)")]
        [Required(ErrorMessage = "Price to Free Cash Flow is required.")]
        public double? PriceToFreeCashFlowTtm { get; set; }

        [Display(Name = "EV/EBITDA")]
        [Required(ErrorMessage = "EV/EBITDA is required.")]
        public double? EvEbitda { get; set; }

        [Display(Name = "EV/Sales")]
        [Required(ErrorMessage = "EV/Sales is required.")]
        public double? EvSales { get; set; }

        [Display(Name = "Book to Market Value")]
        [Required(ErrorMessage = "Book to Market Value is required.")]
        public double? BookToMarketValue { get; set; }

        [Display(Name = "Operating Income/EV")]
        [Required(ErrorMessage = "Operating Income/EV is required.")]
        public double? OperatingIncomeEv { get; set; }

        [Display(Name = "Altman Z Score")]
        [Required(ErrorMessage = "Altman Z Score is required.")]
        public double? AltmanZScore { get; set; }

        public StockPredictionInput ToDomainModel()
        {
            return new StockPredictionInput(
                AdjClose.GetValueOrDefault(),
                Volume.GetValueOrDefault(),
                MarketCap.GetValueOrDefault(),
                PriceToEarningsRatioTtm.GetValueOrDefault(),
                PriceToSalesRatioTtm.GetValueOrDefault(),
                PriceToBookValue.GetValueOrDefault(),
                PriceToFreeCashFlowTtm.GetValueOrDefault(),
                EvEbitda.GetValueOrDefault(),
                EvSales.GetValueOrDefault(),
                BookToMarketValue.GetValueOrDefault(),
                OperatingIncomeEv.GetValueOrDefault(),
                AltmanZScore.GetValueOrDefault());
        }

        public static StockPredictionViewModel FromDomainModel(StockPredictionInput input)
        {
            return new StockPredictionViewModel
            {
                AdjClose = input.AdjClose,
                Volume = input.Volume,
                MarketCap = input.MarketCap,
                PriceToEarningsRatioTtm = input.PriceToEarningsRatioTtm,
                PriceToSalesRatioTtm = input.PriceToSalesRatioTtm,
                PriceToBookValue = input.PriceToBookValue,
                PriceToFreeCashFlowTtm = input.PriceToFreeCashFlowTtm,
                EvEbitda = input.EvEbitda,
                EvSales = input.EvSales,
                BookToMarketValue = input.BookToMarketValue,
                OperatingIncomeEv = input.OperatingIncomeEv,
                AltmanZScore = input.AltmanZScore
            };
        }
    }
}
