using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeneralWebApp.Pages
{
    public class JustForTestModel : PageModel
    {
        [BindProperty]
        public string ForExample { get; set; }
        [BindProperty]
        public string ExampleInput { get; set; }
        [BindProperty]
        public string ProcessResult { get; set; }

        public void OnGet()
        {
            ExampleInput = "";
        }

        public void OnPost()
        {
            ForExample = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff");

            ProcessResult = $"This data had been posted: {ExampleInput}";
        }
    }
}