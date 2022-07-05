using BusinessLayer.Interfaces;
using DatasoftECommerceApi.ViewModels;
using Domain.Entities;
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
            var res = _userService.Login(model.Email, model.Password);

            return Ok(res);
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateVm model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var res = _userService.Register(user, model.Password, model.RePassword);

            return Ok(res);
        }
    }
}
