using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public static class IdentitySeedData
    {
        private const string adminLogin = "Admin";
        private const string adminPassword = "Haslo123!";

        public static async Task EnsurePopulated(UserManager<IdentityUser> userMg)
        {
            IdentityUser user = await userMg.FindByIdAsync(adminLogin);
            if(user == null)
            {
                user = new IdentityUser("Admin");
                await userMg.CreateAsync(user, adminPassword);
            }
        }
    }
}
