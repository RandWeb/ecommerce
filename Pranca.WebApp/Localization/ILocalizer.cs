using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pranca.WebApp.Localization
{
    public interface ILocalizer
    {
        public string this[string name] { get;}
        public string this[string name,params object[] arguments] { get;}
    }
}
