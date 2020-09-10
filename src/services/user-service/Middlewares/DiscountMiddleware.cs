using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using user_service.Core.Dtos;
using user_service.Core.Interfaces;

namespace user_service.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DiscountMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDiscountService _discountService;

        public DiscountMiddleware(RequestDelegate next, IDiscountService discountService)
        {
            _next = next;
            _discountService = discountService;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(
                context.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 30,
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                var RequestBody = JsonConvert.DeserializeObject<DiscountRequestDto>(body);
                var status = _discountService.VerifyDiscount(RequestBody.discountId);
                context.Items["discount"] = status;
                context.Request.Body.Position = 0;
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DiscountMiddlewareExtensions
    {
        public static IApplicationBuilder UseDiscountMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DiscountMiddleware>();
        }
    }
}
