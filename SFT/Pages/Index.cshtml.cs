using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SFT.Pages;

public class Index(ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<Index> _logger = (ILogger<Index>)logger;

    public void OnGet()
    {

    }
}
