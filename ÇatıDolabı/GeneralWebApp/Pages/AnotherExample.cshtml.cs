using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeneralWebApp.Pages
{
    public class AnotherExampleModel : PageModel
    {
        [BindProperty]
        public string FromClient { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var detl = FromClient;
        }
    }
}