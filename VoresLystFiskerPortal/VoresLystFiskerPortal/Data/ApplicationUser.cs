using VoresLystFiskerPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace VoresLystFiskerPortal.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
        public string? BioDescription { get; set; }

        //Navigation Property
        public ICollection<Post>? Posts { get; set; }
    }

}
