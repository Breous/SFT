using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFT.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SFT.Pages.Account
{
    public class RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager) : PageModel
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;

        [BindProperty]
        public required RegisterInput Input { get; set; }

        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            public required string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public required string Password { get; set; }

            [Required]
            public required string FirstName { get; set; }

            [Required]
            public required string LastName { get; set; }

            [Required]
            public required string SustainabilityLevel { get; set; }
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new User
            {
                UserName = Input.Email,
                Email = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                SustainabilityLevel = Input.SustainabilityLevel
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Profile");
            }

            TempData["Error"] = "Invalid login attempt.";
            // or
            TempData["Success"] = "Account created! You can now log in.";

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}