using Azure;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using Newtonsoft.Json;
using System.Net;

namespace GiftCard.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                _logger.LogWarning("CustomException occurred: {Message}", ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Error = ex.Message, IsSuccess = false }));
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning("UnauthorizedAccessException: Unauthorized access attempt detected.");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Error = "Unauthorized",IsSuccess = false }));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception occurred: {Message}", ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Error = "An unexpected error occurred.", IsSuccess = false }));
            }
        }
    }
}
