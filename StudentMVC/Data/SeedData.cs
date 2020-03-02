using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentMVC.Data;
using StudentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVC.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Password is set with the following at the command line:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await CreateUser(serviceProvider, testUserPw, "admin@server.net");
                await CreateRole(serviceProvider, "admin");
                await AddUserToRole(serviceProvider, adminID, "admin");

                SeedDB(context, adminID);
            }
        }

        private static void SeedDB(ApplicationDbContext context, string adminID)
        {
          

        }

        private static async Task<string> CreateUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<WorkForce>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new WorkForce
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> CreateRole(IServiceProvider serviceProvider, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                return await roleManager.CreateAsync(new IdentityRole(role));
            }

            return null;
        }

        private static async Task<IdentityResult> AddUserToRole(IServiceProvider serviceProvider, string uid, string role)
        {
            var userManager = serviceProvider.GetService<UserManager<WorkForce>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            return await userManager.AddToRoleAsync(user, role);
        }
    }

}
