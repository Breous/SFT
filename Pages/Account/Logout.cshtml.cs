using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFT.Models;
using System.Threading.Tasks;

namespace SFT.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task OnGetAsync()
        {
            await _signInManager.SignOutAsync();
            Response.Redirect("/Index");
        }
    }
}



