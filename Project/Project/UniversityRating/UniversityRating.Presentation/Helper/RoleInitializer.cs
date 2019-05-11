using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UniversityRating.Data.Core.DomainModels.Identity;
using UniversityRating.Presentation.Models.User;

namespace UniversityRating.Presentation.Helper
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            const string adminEmail = "admin@gmail.com";
            const string moderatorEmail = "moderator@gmail.com";
            const string password = "A12345";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role{ Name = "admin"});
            }

            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new Role {Name = "moderator"});
            }
            
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role{Name = "user"});
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User {UserName = adminEmail, Email = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            if (await userManager.FindByNameAsync(moderatorEmail) == null)
            {
                var moderator = new User {UserName = moderatorEmail, Email = moderatorEmail };
                IdentityResult result = await userManager.CreateAsync(moderator, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(moderator, "moderator");
                }
            }
        }
    }
}