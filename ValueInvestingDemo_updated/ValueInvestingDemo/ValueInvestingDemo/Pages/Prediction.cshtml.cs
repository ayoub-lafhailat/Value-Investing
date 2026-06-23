using Core.Domain.Exceptions;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValueInvestingDemo.Models;

namespace ValueInvestingDemo.Pages
{
    public class PredictionModel : PageModel
    {
        [BindProperty]
        public StockPredictionViewModel PredictionView { get; set; } = new();

        [BindProperty]
        public int SelectedExampleIndex { get; set; }

        public StockPredictionResult? PredictionResult { get; private set; }
        public List<StockPredictionInput> ExampleInputs { get; private set; } = new();

        private readonly PredictionService _predictionService;

        public PredictionModel(PredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        public void OnGet()
        {
            LoadExamples();
            PredictionView = StockPredictionViewModel.FromDomainModel(ExampleInputs.First());
        }

        public IActionResult OnPostLoadExample()
        {
            LoadExamples();

            if (SelectedExampleIndex < 0 || SelectedExampleIndex >= ExampleInputs.Count)
                SelectedExampleIndex = 0;

            PredictionView = StockPredictionViewModel.FromDomainModel(ExampleInputs[SelectedExampleIndex]);
            ModelState.Clear();

            return Page();
        }

        public IActionResult OnPostPredict()
        {
            LoadExamples();

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var input = PredictionView.ToDomainModel();
                PredictionResult = _predictionService.PredictFutureAdjClose(input);
                return Page();
            }
            catch (PredictionModelException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return Page();
            }
            catch (PredictionServiceFixableException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return Page();
            }
            catch (PredictionServiceException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return Page();
            }
        }

        private void LoadExamples()
        {
            ExampleInputs = _predictionService.GetExampleInputs();
        }
    }
}
