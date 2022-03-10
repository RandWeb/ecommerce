using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pranca.WebApp.Localization;

namespace Pranca.WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILocalizer _localizer;

        public IndexModel(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public void OnGet()
        {
        }
    }
}
