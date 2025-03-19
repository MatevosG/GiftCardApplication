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
              //  _logger.LogInformation("CustomException is : {CustomException}", JsonConvert.SerializeObject(ex));
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Response = ex.Message, IsSuccess = false }));
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Response = "Unauthorized",IsSuccess = false }));
            }
            catch (System.Exception ex)
            {
               // _logger.LogError("GeneralException is : {GeneralException} request context is : {RequestContext}", JsonConvert.SerializeObject(ex), JsonConvert.SerializeObject(context));
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel { Response = "An unexpected error occurred.", IsSuccess = false }));
            }
        }
    }
}
