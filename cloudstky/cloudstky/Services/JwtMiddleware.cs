using cloudstky.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudstky.Services
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
           


             var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);

            if (userId != null)
            {
              //  context.Items["User"] = userId.Value;
                // attach user to context on successful jwt validation
                  context.Items["User"] = userService.GetAccount().Result.Where(m=> m.Id == userId.Value).FirstOrDefault();
            }

            await _next(context);
        }
    }
}
