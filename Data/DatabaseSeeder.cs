using Microsoft.AspNetCore.Identity;

namespace PROG6212_POEPART3.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesandUsers(IServiceProvider serviceProvider)
        {
            // This is two types of management role and user with both of them I can get different type of identity plus to create a username and a password to login on the page I want to do.
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "ClaimRole", "LecturerUser" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var claimRole = new IdentityUser
            {
                UserName = "claimRole11@gmail.com",
                Email = "claimRole11@gmail.com"
            };

            if (userManager.Users.All(u => u.UserName != claimRole.UserName))
            {
                var result = await userManager.CreateAsync(claimRole, "claimRole11@@");
                if (result.Succeeded )
                {
                    await userManager.AddToRoleAsync(claimRole, "ClaimRole");
                }
            }

            var lectureUser = new IdentityUser
            {
                UserName = "lecturerUser11@gmail.com",
                Email = "lecturerUser11@gmail.com"
            };

            if (userManager.Users.All(u => u.UserName != lectureUser.UserName))
            {
                var result = await userManager.CreateAsync(lectureUser, "lecturerUser11@@");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(lectureUser, "LecturerUser");
                }
            }
        }
    }
}
