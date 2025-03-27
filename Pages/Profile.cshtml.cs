using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SFT.Data;
using SFT.Models;
using System.Security.Claims;

namespace SFT.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProfileModel(AppDbContext context)
        {
            _context = context;
        }

        public User? CurrentUser { get; set; }

        public List<Purchase> Purchases { get; set; } = new();
        public int TotalPurchases { get; set; }
        public decimal TotalSpent { get; set; }
        public double AverageRating { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "You must be logged in to view your profile.";
                return RedirectToPage("/Account/Login");
            }

            // Get current user
            CurrentUser = await _context.Users.FindAsync(userId);

            // Get purchases for that user
            Purchases = await _context.Purchases
                .Where(p => p.UserId == userId)
                .ToListAsync();

            // Summary
            TotalPurchases = Purchases.Count;
            TotalSpent = Purchases.Sum(p => p.Price);
            AverageRating = Purchases.Any() ? Purchases.Average(p => p.Rating) : 0;

            return Page();
        }
    }
}
