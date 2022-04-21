using System;
using System.Threading.Tasks;
using Games.DataAcess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Web
{
    public static class SeedData
    {
         public static async Task CreateRoles(IServiceProvider serviceProvider)
         {
            //initializing custom roles 
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();
            var roleNames = new[] { "Admin", "User" };
            
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }

            var powerUser = new UserEntity
            {
                UserName = "Administrator",
                Email = "admin@localhost",
            };
            
            var userPwd = "P@ssw0rd";
            var user = await userManager.FindByEmailAsync("admin@localhost");

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPwd);
                
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}
