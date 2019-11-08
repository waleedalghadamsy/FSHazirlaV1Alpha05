using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.Menüler
{
    public class YeniEkleModel : PageModel
    {
        [BindProperty]
        public List<SelectListItem> Restoranlar { get; set; }
        [BindProperty]
        public int RestoranId { get; set; }
        [BindProperty]
        public string MenüAd { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }
        public void OnGet()
        {

        }
    }
}