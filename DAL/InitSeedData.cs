using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class InitSeedData
    {
        private static string[] roles = { "Admin", "Editor", "User" };
        private static ApplicationUser[] users =
            {
                new ApplicationUser()
                {
                    Email="admin@gmail.com",
                    IsVip=true,
                    IsEnable = true,
                    UserName = "admin",
                    PhoneNumber ="0987654321"
                },
                new ApplicationUser()
                {
                    Email="editor@gmail.com",
                    IsVip=true,
                    IsEnable = true,
                    UserName = "editor",
                    PhoneNumber ="0987654322"
                },
                new ApplicationUser()
                {
                    Email="user.normal@gmail.com",
                    IsVip=false,
                    IsEnable = true,
                    UserName = "usernormal",
                    PhoneNumber ="0987654323"
                },
                new ApplicationUser()
                {
                    Email="user.vip@gmail.com",
                    IsVip=true,
                    IsEnable = true,
                    UserName = "uservip",
                    PhoneNumber ="0987654324"
                }
            };

        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            foreach (var user in users)
            {
                if (userManager.FindByNameAsync(user.UserName).Result == null)
                {
                    IdentityResult result = userManager.CreateAsync(user, user.UserName + "@123ABC").Result;

                    if (result.Succeeded)
                    {
                        switch (user.UserName)
                        {
                            case "admin":
                                userManager.AddToRoleAsync(user, "Admin").Wait();
                                userManager.AddToRoleAsync(user, "Editor").Wait();
                                userManager.AddToRoleAsync(user, "User").Wait();
                                break;
                            case "editor":
                                userManager.AddToRoleAsync(user, "Editor").Wait();
                                userManager.AddToRoleAsync(user, "User").Wait();
                                break;
                            default:
                                userManager.AddToRoleAsync(user, "User").Wait();
                                break;
                        }

                    }
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (string role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    IdentityRole roleIdentity = new IdentityRole();
                    roleIdentity.Name = role;
                    roleIdentity.NormalizedName = role.ToUpper();
                    IdentityResult roleResult = roleManager.CreateAsync(roleIdentity).Result;
                }
            }
        }
    }
}
