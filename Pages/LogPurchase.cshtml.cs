using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SFT.Models;
using SFT.Data;

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
        public Purchase Purchase { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Get the logged-in user’s ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Set it BEFORE validation
            Purchase.UserId = userId;

            // Validate the full model
            if (!ModelState.IsValid)
            {
                // Optional: show debug messages in Output
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Validation Error - {entry.Key}: {error.ErrorMessage}");
                    }
                }

                TempData["Error"] = "Please correct the form errors.";
                return Page();
            }

            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "Could not identify the current user.";
                return Page();
            }

            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Your purchase was logged successfully!";
            return RedirectToPage("/Profile");
        }
    }
}