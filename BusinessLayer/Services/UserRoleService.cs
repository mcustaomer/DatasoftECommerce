using BusinessLayer.Generic;
using BusinessLayer.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly RoleManager<UserRole> _roleManager;

        public UserRoleService(RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void CreateOrUpdateRole(string id, string name)
        {
            if(id != null)
            {
                var role = _roleManager.FindByIdAsync(id).Result;
                role.Name = name;
                _roleManager.UpdateAsync(role);
            }

            var result = _roleManager.CreateAsync(new UserRole
            {
                Name = name,
            }).Result;

            if (result.Succeeded)
            {
            }
            else
            {
            }
        }

        public void DeleteRole(string name)
        {
            var role = _roleManager.FindByNameAsync(name).Result;

            var res = _roleManager.DeleteAsync(role).Result;

            if (res.Succeeded)
            {
            }
            else
            {
            }
        }

        public void RoleList()
        {
            _roleManager.Roles.ToList();
        }
    }
}
