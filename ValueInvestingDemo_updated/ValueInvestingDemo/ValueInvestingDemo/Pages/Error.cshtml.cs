using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ValueInvestingDemo.Pages
{
    public class ErrorModel : PageModel
    {
        public string? ErrorMessage { get; private set; }

        public void OnGet()
        {
            ErrorMessage = TempData["Error"]?.ToString();
        }
    }
}
