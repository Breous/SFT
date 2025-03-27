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
                TempData["Error"] = "You must be logged in.";
                return RedirectToPage("/Account/Login");
            }

            CurrentUser = await _context.Users.FindAsync(userId);
            Purchases = await _context.Purchases
                .Where(p => p.UserId == userId)
                .ToListAsync();

            TotalPurchases = Purchases.Count;
            TotalSpent = Purchases.Sum(p => p.Price);
            AverageRating = Purchases.Any() ? Purchases.Average(p => p.Rating) : 0;

            return Page();
        }

        public async Task<IActionResult> OnPostExportCsvAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return RedirectToPage("/Account/Login");

            var purchases = await _context.Purchases.Where(p => p.UserId == userId).ToListAsync();

            var csvLines = new List<string> { "Brand,Item,Material,Price,Rating" };
            csvLines.AddRange(purchases.Select(p => $"{p.Brand},{p.ItemName},{p.Material},{p.Price},{p.Rating}"));

            var bytes = System.Text.Encoding.UTF8.GetBytes(string.Join("\n", csvLines));
            return File(bytes, "text/csv", "MyPurchases.csv");
        }

        public async Task<IActionResult> OnPostExportTxtAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return RedirectToPage("/Account/Login");

            var purchases = await _context.Purchases.Where(p => p.UserId == userId).ToListAsync();

            var lines = purchases.Select(p =>
                $"Brand: {p.Brand}, Item: {p.ItemName}, Material: {p.Material}, Price: ${p.Price}, Rating: {p.Rating}");

            var bytes = System.Text.Encoding.UTF8.GetBytes(string.Join("\n", lines));
            return File(bytes, "text/plain", "MyPurchases.txt");
        }

        public async Task<IActionResult> OnPostExportJsonAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return RedirectToPage("/Account/Login");

            var purchases = await _context.Purchases.Where(p => p.UserId == userId).ToListAsync();

            var json = System.Text.Json.JsonSerializer.Serialize(purchases);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "MyPurchases.json");
        }
    }
}
