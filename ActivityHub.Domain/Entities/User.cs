
using Microsoft.AspNetCore.Identity;

namespace ActivityHub.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation property
        public ICollection<UserActivity> UserActivities { get; set; }
    }
}
