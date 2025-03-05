using Microsoft.AspNetCore.Identity;
using serverSide.Models;

namespace serverSide.CommonUtilities
{
    public class DataSeeder
    {
        public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            
            string adminEmail = "cdkAdmin@cdk.edu.ph";
            string adminPassword = "cdkAdmin2002/"; 

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new User
                {
                    UserId = "Admin",
                    UserName = adminEmail,
                    NormalizedEmail = adminEmail,
                    Firstname = "Colegio",
                    Middlename = "de Kidapawan",
                    Lastname = "Admin",
                    Email = adminEmail,
                    
                };

                var result = await userManager.CreateAsync(newAdmin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }

            }
        }
    }
}
