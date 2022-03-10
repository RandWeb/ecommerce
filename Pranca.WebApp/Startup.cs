using Framework.Application.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using Pranca.Infrastructure.Core.Configuraction;
using Pranca.WebApp.Autentication;
using Pranca.WebApp.ConfigureServiceses;
using Pranca.WebApp.Localization.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Pranca.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalizationService("Localization/Resource");
            services.WebEncoderService();

            services.AddRazorPagesService()
                .AddCustomLocalization("Localization/Resource")
                .AddCustomDataAnnotationLocalization(services,typeof(SharedResource));

            services.AddInject();
            services.AddCustomIdentitiy()
                    .AddErrorDescriber<CustomErrorDescriber>();
            services.AddCustomAuthenticatinJwt(AuthConstants.ValidationKey,AuthConstants.SecretCode,AuthConstants.Audience, AuthConstants.Issuer)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseLocalizationMidleware(new List<CultureInfo> { new CultureInfo("en-Us"), new CultureInfo("fa-IR") },"fa-IR");

            app.AddCustomAuthentication(AuthConstants.CookieName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
