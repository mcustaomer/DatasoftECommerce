using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbLogLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly HttpExceptionLogService _httpExceptionLogService;

        public LogsController(HttpExceptionLogService httpExceptionLogService) => _httpExceptionLogService = httpExceptionLogService;

        [Authorize(Roles = "Manager, Assistant")]
        [HttpGet("get-all")]
        public IActionResult GetLogs() => Ok(_httpExceptionLogService.Get());
    }
}
