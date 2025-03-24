using Microsoft.AspNetCore.Identity;

namespace SFT.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SustainabilityLevel { get; set; }
    }
}