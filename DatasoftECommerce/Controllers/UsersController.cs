using BusinessLayer.Interfaces;
using DatasoftECommerceApi.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginVm model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var res = _userService.Login(model.Email, model.Password);

            return Ok(res);
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateVm model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var res = _userService.Register(user, model.Password, model.RePassword);

            return Ok(res);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("role-assign")]
        public IActionResult RoleAssign(RoleAssignVm model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var res = _userService.RoleAssign(model.UserId, model.RoleName, model.HasRole);

            return Ok(res);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("add-user")]
        public IActionResult UserAdd(UserAddVm model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var res = _userService.UserAdd(user, model.RoleName, model.Password, model.RePassword);

            return Ok(res);
        }
    }
}
