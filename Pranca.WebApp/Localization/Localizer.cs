using Microsoft.Extensions.Localization;
using Pranca.WebApp.Localization.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pranca.WebApp.Localization
{
    public class Localizer : ILocalizer
    {
        private readonly IStringLocalizer _sharedLocalizer;

        public Localizer(IStringLocalizer sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }

        public Localizer(IStringLocalizerFactory stringLocalizerFactory)
        {
            _sharedLocalizer = new FactoryLoaclizer().Set(stringLocalizerFactory,typeof(SharedResource));
        }
        private string Get(string name) => _sharedLocalizer[name];
        private string Get(string name,params object[] argumants) => _sharedLocalizer[name,argumants];
        public string this[string name] => Get(name);

        public string this[string name, params object[] arguments] => Get(name,arguments);
        
        
    }
}
