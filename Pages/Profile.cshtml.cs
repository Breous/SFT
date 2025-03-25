using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SFT.Data;
using SFT.Models;
using System.Security.Claims;

namespace SFT.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;

        public ProfileModel(UserManager<User> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public User CurrentUser { get; set; }
        public List<Purchase> Purchases { get; set; } = new(); // Capital “P”
        public decimal TotalSpent { get; set; }
        public double AverageRating { get; set; }
        public int TotalPurchases => Purchases?.Count ?? 0;

        public async Task<IActionResult> OnPostExportAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login");

            var purchases = await _context.Purchases
                .Where(p => p.UserId == user.Id)
                .ToListAsync();

            var lines = new List<string> { "Brand,Item,Material,Price,Rating" };
            lines.AddRange(purchases.Select(p =>
                $"{p.Brand},{p.ItemName},{p.Material},{p.Price},{p.Rating}"));

            var content = string.Join(Environment.NewLine, lines);
            var bytes = System.Text.Encoding.UTF8.GetBytes(content);

            return File(bytes, "text/plain", "purchase-history.txt");
        }
    }
}