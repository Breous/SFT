using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using SFT.Models;
using SFT.Data;
using System.Security.Claims;

namespace SFT.Pages
{
    [Authorize]
    public class LogPurchaseModel : PageModel
    {
        private readonly AppDbContext _context;

        public LogPurchaseModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public required Purchase Purchase { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (!ModelState.IsValid || string.IsNullOrEmpty(userId))
                return Page();

            Purchase.UserId = userId;
            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile");
        }
    }
}
