using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Middlewares
{
    public class AuthMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var auth = context.Request.Headers;
            if (auth.ContainsKey("Authorization"))
            {
                if (auth["Authorization"] == "Basic admin:admin")
                { await next.Invoke(context); return; }
            }
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Auth is invalid");
        }
    }
}
