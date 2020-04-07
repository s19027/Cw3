﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        //Our code
        await _next(httpContext);
        
    }
}

