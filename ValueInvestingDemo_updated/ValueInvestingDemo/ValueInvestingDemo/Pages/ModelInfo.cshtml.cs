using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ValueInvestingDemo.Pages
{
    public class ModelInfoModel : PageModel
    {
        public List<string> FeatureNames { get; private set; } = new();

        public void OnGet()
        {
            FeatureNames = new List<string>
            {
                "Adj. Close",
                "Volume",
                "Market-Cap",
                "Price to Earnings Ratio (ttm)",
                "Price to Sales Ratio (ttm)",
                "Price to Book Value",
                "Price to Free Cash Flow (ttm)",
                "EV/EBITDA",
                "EV/Sales",
                "Book to Market Value",
                "Operating Income/EV",
                "Altman Z Score"
            };
        }
    }
}
