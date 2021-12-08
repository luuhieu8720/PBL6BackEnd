using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using PBL6BackEnd.Extensions;
using PBL6BackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PBL6BackEnd.Services
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate next;

        public TokenProviderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var authenticateInfo = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            var bearerTokenIdentity = authenticateInfo?.Principal;
            if (bearerTokenIdentity?.Identity is ClaimsIdentity identity)
            {
                var userId = Guid.Parse(identity.GetClaimValue(ClaimTypes.NameIdentifier));
                var user = await userRepository.GetById(userId);
                context.User = new UserClaimsPrincipal(identity, user);
            }
            await next(context);
        }
    }
}
