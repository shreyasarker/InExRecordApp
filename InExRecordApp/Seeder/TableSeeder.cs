using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InExRecordApp.Seeder
{
    public class TableSeeder
    {
        public static async Task Initialize(AppDbContext context,
                              UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();


            string srAccountant = "SrAccountant";
            string jrAccountant = "JrAccountant";

           

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(srAccountant) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(srAccountant));
            }
            if (await roleManager.FindByNameAsync(jrAccountant) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(jrAccountant));
            }

            if (await userManager.FindByEmailAsync("siddharthya@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "siddharthya@gmail.com",
                    Name = "Siddharthya Chowdhury",
                    Email = "siddharthya@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, srAccountant);
                }
            }

            if (await userManager.FindByNameAsync("sohini@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "sohini@gmail.com",
                    Name = "Sohini Azam",
                    Email = "sohini@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, jrAccountant);
                }
            }

            if (await userManager.FindByNameAsync("sen@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "sen@gmail.com",
                    Name = "A K Sen",
                    Email = "sen@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, jrAccountant);
                }
            }

            if (await userManager.FindByNameAsync("dd@dd.dd") == null)
            {
                var user = new AppUser
                {
                    UserName = "thomas@gmail.com",
                    Name = "Thomas Barua",
                    Email = "thomas@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, jrAccountant);
                }
            }
        }
    }
}
