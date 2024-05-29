using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiCore.Models;
using WebApiCore.Models.Response;

namespace WebApiCore.MiddleWare
{
    public class IpValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _optionsMonitor;
        public IpValidationMiddleware(RequestDelegate next, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _next = next;
            _optionsMonitor = optionsMonitor.CurrentValue;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var lstIp = _optionsMonitor.IpAllow.Split(';');
            var ipAccess = httpContext.Connection.RemoteIpAddress.ToString();
            if (!lstIp.Contains(ipAccess))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                httpContext.Response.ContentType = "text/plain";
                using (var writer = new StreamWriter(httpContext.Response.Body))
                    await writer.WriteLineAsync("Ip unauthorized");
                await _next(httpContext);
            }
            else
            {
                await _next(httpContext);
            }    
        }
    }
}
