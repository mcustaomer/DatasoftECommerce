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

        public string CreateOrUpdateRole(string id, string name)
        {
            if(id != "0")
            {
                var role = _roleManager.FindByIdAsync(id).Result;
                role.Name = name;
                _roleManager.UpdateAsync(role);

                return "Başarıyla güncelleme sağlandı.";
            }

            var result = _roleManager.CreateAsync(new UserRole
            {
                Name = name,
            }).Result;

            if (result.Succeeded)
            {
                return "Ekleme başarıyla sağlandı.";
            }
            else
            {
                return "Ekleme başarısız.";
            }
        }

        public string DeleteRole(string name)
        {
            var role = _roleManager.FindByNameAsync(name).Result;

            var res = _roleManager.DeleteAsync(role).Result;

            if (res.Succeeded)
            {
                return "Silme işlemi başarılı.";
            }
            else
            {
                return "Silme işlemi başarısız.";
            }
        }

        public List<UserRole> RoleList()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
