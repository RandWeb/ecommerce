using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Common.Extentions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;

namespace Pranca.WebApp.Middlewares
{
    public class JwtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private string _validationKey;
        private string _cookieName;
        public JwtAuthenticationMiddleware(RequestDelegate next, string validationKey, string cookieName)
        {
            _next = next;
            _validationKey = validationKey;
            _cookieName = cookieName;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            SetHeaderWithCookie(context);

            await _next(context);
        }

        /// <summary>
        /// مقدار دهی  header
        /// به وسله کوکی دریافت شده از کلاینت
        /// </summary>
        /// <param name="context"></param>
        private void SetHeaderWithCookie(HttpContext context)
        {
            if (context.Request.Cookies[_cookieName] != null)
            {
                var encryptToken = context.Request.Cookies[_cookieName].ToString();
                context.Request.Headers.Add("Authorization", encryptToken.AesEncrypt(_validationKey));
            }
        }
    }
}
