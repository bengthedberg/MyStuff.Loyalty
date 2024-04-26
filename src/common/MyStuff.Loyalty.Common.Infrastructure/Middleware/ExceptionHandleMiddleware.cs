using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyStuff.Loyalty.Common.Infrastructure;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(ex, httpContext);
        }
    }

    private async Task HandleException(Exception ex, HttpContext httpContext)
    {


        if (ex is InvalidOperationException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "Invalid operation",
                Status = 400,
                Detail = "Invalid operation",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Instance = httpContext.Request.Path
            });
        }
        else if (ex is BadHttpRequestException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "Invalid request",
                Status = 400,
                Detail = "Invalid operation",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Instance = httpContext.Request.Path
            });
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "Internal Error",
                Status = 500,
                Detail = ex.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Instance = httpContext.Request.Path
            });
        }


    }
}