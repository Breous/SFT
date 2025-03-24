using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SFT.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class Error : PageModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId
    {
        get
        {
            return !string.IsNullOrEmpty(RequestId);
        }
    }

    private readonly ILogger<ErrorModel> _logger;

    public Error(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() => RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
}

