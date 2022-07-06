using BusinessLayer.Generic;
using BusinessLayer.Interfaces;
using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
                    var token = CreateToken(user);

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
            if (password != rePassword)
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
                var token = CreateToken(user);

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

        public string RoleAssign(string userId, string roleName, bool hasRole)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            if (hasRole)
            {
                var addRole = _userManager.AddToRoleAsync(user, roleName).Result;
                return "Rol başarıyla eklendi";
            }
            else
            {
                var removeRole = _userManager.RemoveFromRoleAsync(user, roleName).Result;
                return "Rol başarıyla kaldırıldı";
            }
        }

        public string UserAdd(User user, string roleName, string password, string rePassword)
        {
            if (password != rePassword)
            {
                return "Şifreler aynı değil";
            }

            var userFound = _userManager.FindByEmailAsync(user.Email).Result;

            if (userFound is not null)
                return "Bu email ile bir kullanıcı oluşturulmuş";

            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {

                var res = _userManager.AddToRoleAsync(user, roleName).Result;

                return "Kullanıcı oluşturma başarılı";
            }
            else
            {
                return "Kullanıcı oluşturma başarısız";
            }
        }

        private string CreateToken(User user)
        {
            var role =_userManager.GetRolesAsync(user).Result.FirstOrDefault();
            
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("email", user.Email),
                        new Claim("username", user.UserName),
                        new Claim(ClaimTypes.Role, role)
                    };

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cN!o0xaT$ANePP-dkU{ET07WR;>)fY"));

            var token = new JwtSecurityToken(
                issuer: "http://google.com",
                audience: "http://google.com",
                expires: DateTime.UtcNow.AddHours(2),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
