using KronikiPodwalaV2.Models;
using Microsoft.AspNetCore.Identity;

namespace KronikiPodwalaV2
{
    public class SeedAdmin
    {
        public static async Task Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string passwd = "P@ssw0rd";
            string adminEmail = "admin@world.com";
            var roles = new[] { "Admin", "Student" };
            foreach (var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role)) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if(await userManager.FindByEmailAsync(adminEmail)==null)
            {
                AppUser admin = new AppUser();
                admin.Email = adminEmail;
                admin.UserName = adminEmail;
                admin.EmailConfirmed = true;

                await userManager.CreateAsync (admin, passwd);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
     }
}
