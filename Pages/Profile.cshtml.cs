using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFT.Models;
using System.Security.Claims;

namespace SFT.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public User CurrentUser { get; set; }

        public ProfileModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            CurrentUser = await _userManager.FindByEmailAsync(email);

            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            return Page();
        }
    }
}
