using Microsoft.AspNetCore.Identity;
using Pranca.WebApp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pranca.WebApp.Autentication
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        private readonly ILocalizer _localizer;

        public CustomErrorDescriber(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError() {Code = nameof(DefaultError),Description = _localizer["DefaultError"] };
        }
    }
}
