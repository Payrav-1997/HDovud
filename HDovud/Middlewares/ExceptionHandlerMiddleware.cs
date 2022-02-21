using HDovud.Entities.Common;
using HDovud.Entities.Errors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HDovud.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case ExceptionWithStatusCode e:
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response { StatusCode = (int)e.StatusCode, Message = e.Message }));
                default:
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response { StatusCode = 500, Message = ex.Message }));
            }


        }
    }
}
