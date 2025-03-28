using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SFT.Models;

public class LoginModel : PageModel
{
    private readonly SignInManager<User> _signInManager;

    public LoginModel(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty]
    public required string Email { get; set; }

    [BindProperty]
    public required string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {

        var result = await _signInManager.PasswordSignInAsync(Email, Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToPage("/Profile");
        }

        TempData["Error"] = "Invalid login attempt.";
        // or
        TempData["Success"] = "Account created! You can now log in.";

        ModelState.AddModelError("", "Invalid login attempt.");
        return Page();
    }
}
// This class handles only profile data for the logged-in user
// Follows SRP (Single Responsibility Principle)
