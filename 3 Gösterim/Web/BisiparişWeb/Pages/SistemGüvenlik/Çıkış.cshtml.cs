using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    public class ÇıkışModel : PageModel
    {
        public async Task OnGet()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Hata, ex);
                throw ex;
            }
        }
    }
}