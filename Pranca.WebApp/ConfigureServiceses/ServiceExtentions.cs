using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using Pranca.WebApp.Localization;
using Pranca.WebApp.Localization.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Pranca.WebApp.ConfigureServiceses
{
    public static class ServiceExtentions
    {
        public static IServiceCollection WebEncoderService(this IServiceCollection service)
        {
           return service.Configure<WebEncoderOptions>(options => {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.Arabic, UnicodeRanges.BasicLatin);
            });
        }
        public static IMvcBuilder AddRazorPagesService(this IServiceCollection service)
        {
          return  service.AddRazorPages(options => {
                options.Conventions.AddPageRoute("/Home/Index", "");
            });
        }
        public static IServiceCollection AddLocalizationService(this IServiceCollection service,string resourcePath)
        {
            return service.AddLocalization(r => r.ResourcesPath = resourcePath);
        }

        public static IApplicationBuilder UseLocalizationMidleware(this IApplicationBuilder app,List<CultureInfo> cultureInfos,string defCultureName="fa-IR")
        {
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(defCultureName),
                SupportedCultures = cultureInfos,
                SupportedUICultures = cultureInfos,
                RequestCultureProviders = new List<IRequestCultureProvider>() { 
                                                                                  new CookieRequestCultureProvider(),
                                                                                  new QueryStringRequestCultureProvider()
                                                                               }
            };
            return app.UseRequestLocalization(options); 
        }

        public static IMvcBuilder AddCustomLocalization(this IMvcBuilder builder,string resourcePath)
        {
            builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,options=> {
                options.ResourcesPath = resourcePath;
            });
            return builder;
        }

        public static IMvcBuilder AddCustomDataAnnotationLocalization(this IMvcBuilder builder,IServiceCollection service,Type sharedResource)
        {
            builder.AddDataAnnotationsLocalization(options =>
            {
                var localizer = new FactoryLoaclizer().Set(service, sharedResource);
                options.DataAnnotationLocalizerProvider = (t, f) => localizer;
            });
            return builder;
        }


        public static IServiceCollection AddInject(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizer,Localizer>();
            return services;
        }

    }
}
