using MainProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Data
{
    public class SeedData
    {
        public static string ROLE_USER_ADMIN = "Admin";
        public static string ROLE_USER_MANAGER = "Manager";
        public static string ROLE_USER_GUEST = "Guest";
        public static string USER_PICTURE_BIG = "https://graph.facebook.com/1187008678111344/picture?width=160&height=160";
        public static string USER_PICTURE_SMAILL = "https://graph.facebook.com/1187008678111344/picture?width=128&height=128";
        //public static async Task CreateExampleAccount(IServiceProvider serviceProvider
        //    )
        //{
        //    using (var context = new ApplicationDbContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        //    {
        //        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!context.Roles.Any())
        //        {
        //            context.AddRange(
        //                new IdentityRole { Name = ROLE_USER_ADMIN },
        //                new IdentityRole { Name = ROLE_USER_MANAGER },
        //                new IdentityRole { Name = ROLE_USER_GUEST }
        //                );
        //            context.SaveChanges();
        //        }
        //        if (!context.Users.Any())
        //        {
        //            //Tai khoan Admin
        //            ApplicationUser useradmin = new ApplicationUser
        //            {
        //                UserName = ROLE_USER_ADMIN,
        //                Email = ROLE_USER_ADMIN + "@gmail.com",
        //                FullName = ROLE_USER_ADMIN,
        //                PictureBig = USER_PICTURE_BIG,
        //                PictureSmall = USER_PICTURE_SMAILL
        //            };
        //            context.AddRange(new ApplicationUser { })
        //            IdentityResult result = await userManager.CreateAsync(useradmin, ROLE_USER_ADMIN);
        //            if (result.Succeeded)
        //            {
        //                await userManager.AddToRoleAsync(useradmin, ROLE_USER_ADMIN);
        //            }

        //            //Tai khoan Manager
        //            ApplicationUser usermanager = new ApplicationUser
        //            {
        //                UserName = ROLE_USER_MANAGER,
        //                Email = ROLE_USER_MANAGER + "@gmail.com",
        //                FullName = ROLE_USER_MANAGER,
        //                PictureBig = USER_PICTURE_BIG,
        //                PictureSmall = USER_PICTURE_SMAILL,
        //            };
        //            result = await userManager
        //            .CreateAsync(usermanager, ROLE_USER_MANAGER);
        //            if (result.Succeeded)
        //            {
        //                await userManager.AddToRoleAsync(usermanager, ROLE_USER_MANAGER);
        //            }
        //            //Tai khoan Manager
        //            ApplicationUser userguest = new ApplicationUser
        //            {
        //                UserName = ROLE_USER_GUEST,
        //                Email = ROLE_USER_GUEST + "@gmail.com",
        //                FullName = ROLE_USER_GUEST,
        //                PictureBig = USER_PICTURE_BIG,
        //                PictureSmall = USER_PICTURE_SMAILL,
        //            };
        //            result = await userManager
        //            .CreateAsync(userguest, ROLE_USER_GUEST);
        //            if (result.Succeeded)
        //            {
        //                await userManager.AddToRoleAsync(userguest, ROLE_USER_GUEST);
        //            }
        //        }
        //    }
        //}
    }
}
         