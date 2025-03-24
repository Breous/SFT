using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SFT.Pages
{
    public class Privacy(ILogger<Privacy> logger) : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger = (ILogger<PrivacyModel>)logger;

        public void OnGet()
        {
            // Only ONE OnGet() method here
        }
    }
}

