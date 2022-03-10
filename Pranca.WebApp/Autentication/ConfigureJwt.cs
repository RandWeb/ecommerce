using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pranca.WebApp.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.WebApp.Autentication
{
    public static class ConfigureJwt
    {
        private static string _secretKey;
        private static byte [] _secretCode;
        public static void AddCustomAuthenticatinJwt(this IServiceCollection services,string secretKey,string secretCode,string audience,string issuer)
        {
            _secretKey = secretKey;
            _secretCode = ASCIIEncoding.ASCII.GetBytes(secretCode);
            var tokenValidationParameters = new TokenValidationParameters() {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secretCode),
                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true,
                ValidAudience = audience,

                ValidateIssuer = true,
                ValidIssuer = issuer
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt=> {
                jwt.Audience = "";
                jwt.TokenValidationParameters = tokenValidationParameters ;
            });
        }

        public static void AddCustomAuthentication(this IApplicationBuilder app, string cookieName)
        {
            app.UseMiddleware<JwtAuthenticationMiddleware>(_secretKey,cookieName);
            app.UseAuthentication();
            app.UseAuthorization();

        }
    }
}
