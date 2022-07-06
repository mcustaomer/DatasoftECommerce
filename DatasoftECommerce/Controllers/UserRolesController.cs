using BusinessLayer.Interfaces;
using DatasoftECommerceApi.ViewModels;
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
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService) => _userRoleService = userRoleService;

        [Authorize(Roles = "Manager")]
        [HttpPost("create-or-update")]
        public IActionResult CreateOrUpdate(UserRoleCreateVm model)
        {
            var res = _userRoleService.CreateOrUpdateRole(model.Id, model.Name);

            return Ok(res);
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete/{name}")]
        public IActionResult Delete(string name)
        {
            var res = _userRoleService.DeleteRole(name);

            return Ok(res);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("list")]
        public IActionResult List() => Ok(_userRoleService.RoleList()); 
    }
}
