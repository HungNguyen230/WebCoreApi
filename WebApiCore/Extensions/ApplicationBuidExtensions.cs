using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.MiddleWare;

namespace WebApiCore.Extensions
{
    public static class ApplicationBuidExtensions
    {
        public static IApplicationBuilder UseIpValidateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpValidationMiddleware>();
        }
    }
}
