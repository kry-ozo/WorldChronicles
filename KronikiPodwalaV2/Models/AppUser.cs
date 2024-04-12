using Microsoft.AspNetCore.Identity;

namespace KronikiPodwalaV2.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
