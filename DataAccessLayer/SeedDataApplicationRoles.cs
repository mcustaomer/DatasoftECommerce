using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class SeedDataApplicationRoles
    {
        public static void SeedRoles(RoleManager<UserRole> roleManager)
        {
            var roleList = new List<string>()
            {
                "Manager",
                "Assistant",
                "User"
            };

            foreach (var role in roleList)
            {
                var res = roleManager.RoleExistsAsync(role).Result;

                if (!res)
                {
                    var result = roleManager.CreateAsync(new UserRole
                    {
                        Name = role
                    }).Result;
                }
            }
        }
    }
}
