using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Extensions
{
    public static class ServiceExtensionCollections
    {
        public static void AddAuthInfo(this IServiceCollection services)
        {
            services.AddScoped<IAuthInfo>(ctx =>
            {
                var httpContext = ctx.GetService<IHttpContextAccessor>();
                var request = httpContext.HttpContext.Request;
                var sso = ctx.GetService<ISecurityContext>();
                var authInfo = new AuthInfo();
                if (request != null)
                {
                    if (request.Headers.ContainsKey("Authorization"))
                    {
                        authInfo.Token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                    }
                }
                authInfo.Username = sso.GetUser(authInfo.Token).Username;
                return authInfo;
            });
        }
    }
}
