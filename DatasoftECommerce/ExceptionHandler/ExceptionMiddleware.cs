using Microsoft.AspNetCore.Http;
using MongoDbLogLayer.LogEntities;
using MongoDbLogLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.ExceptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionLogService _httpExceptionLogService;
        public ExceptionMiddleware(RequestDelegate next, HttpExceptionLogService httpExceptionLogService)
        {
            _httpExceptionLogService = httpExceptionLogService;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex, _httpExceptionLogService);
            }
        }

        private static void HandleExceptionAsync(HttpContext httpContext, Exception ex, HttpExceptionLogService logService)
        {
            var exception = new HttpExceptionLog()
            {
                Message = ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
                Data = ex.Data,
                CreateDate = DateTime.Now
            };

            logService.Insert(exception);
        }
    }
}
