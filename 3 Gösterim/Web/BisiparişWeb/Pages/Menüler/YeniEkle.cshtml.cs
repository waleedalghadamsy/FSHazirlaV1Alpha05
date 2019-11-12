using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.Menüler
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniEkleModel : PageModel
    {
        [BindProperty]
        public List<SelectListItem> Restoranlar { get; set; }
        [BindProperty]
        public int RestoranId { get; set; }
        [BindProperty]
        public string MenüAd { get; set; }
        [BindProperty]
        public List<SelectListItem> Kategoriler { get; set; }
        [BindProperty]
        public int KategoriId { get; set; }
        [BindProperty]
        public int AltKategoriId { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }
        public void OnGet()
        {

        }
    }
}