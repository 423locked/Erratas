using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Erratas.Domain.Extensions
{
    public static class Extensions
    {
        public static Guid GetUserId(this IHttpContextAccessor httpContext)
        {
            if (httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier) == null)
                return Guid.Empty;
            return Guid.Parse(httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
