using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeneralWebApp
{
    public class CheckThisModel : PageModel
    {
        [BindProperty]
        public string ForExample { get; set; }

        public void OnGet()
        {
            ForExample = "";
        }

        public void OnPost()
        {
            ForExample = $"Time is {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")}";
        }
    }
}