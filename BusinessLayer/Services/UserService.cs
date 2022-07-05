using BusinessLayer.Generic;
using BusinessLayer.Interfaces;
using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;

        public UserService(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public UserResponseDto Login(string email, string password)
        {
            var user = _userManager.FindByEmailAsync(email).Result;

            if (user is null)
            {
                return new UserResponseDto
                {
                    Status = false,
                    Explanation = "Bu mail ile kayıtlı kullanıcı bulunamamaktadır."
                };
            }
            else
            {
                var result = _userManager.CheckPasswordAsync(user, password).Result;

                if (!result)
                {
                    return new UserResponseDto
                    {
                        Status = false,
                        Explanation = "Parola hatalı!"
                    };
                }
                else
                {
                    var token = _userManager.GenerateUserTokenAsync(user, "email", "token").Result;

                    return new UserResponseDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.UserName,
                        Token = token,
                        Status = true,
                        Explanation = "Giriş başarılı."
                    };
                }
            }
        }

        public UserResponseDto Register(User user, string password, string rePassword)
        {
            if(password != rePassword)
            {
                return new UserResponseDto
                {
                    Explanation = "Şifreler aynı değil",
                    Status = false
                };
            }

            var userFound = _userManager.FindByEmailAsync(user.Email).Result;

            if (userFound is not null)
                return new UserResponseDto
                {
                    Status = false,
                    Explanation = "Bu email ile bir kullanıcı oluşturulmuş"
                };
            
            var result = _userManager.CreateAsync(user, password).Result;
            
            if (result.Succeeded)
            {
                var token = _userManager.GenerateUserTokenAsync(user, "email", "token").Result;
                
                var res = _userManager.AddToRoleAsync(user, "Manager").Result;
                
                return new UserResponseDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = token,
                    Status = true,
                    Explanation = "Kullanıcı oluşturma başarılı"
                };
            }
            else
            {
                return new UserResponseDto
                {
                    Status = false,
                    Explanation = "Kullanıcı oluşturma başarısız"
                };
            }
        }

        public void RoleAssign(string userId, string roleName, bool hasRole)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            if (!hasRole)
                _userManager.AddToRoleAsync(user, roleName);
            else
                _userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
