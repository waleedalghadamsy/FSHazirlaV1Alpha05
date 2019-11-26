using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişWeb.Modeller.SistemGüvenlik;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<KullanıcıGörünümModel> Kullanıcılar { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                //await BisiparişWebYardımcı.AyıklamaKaydet("Getting users...");

                var klnclr = await Yardımcılar.GüvenlikYardımcı.KullanıcılarAl();

                if (klnclr != null && klnclr.Any())
                {
                    Kullanıcılar = new List<KullanıcıGörünümModel>();

                    foreach (var klnc in klnclr)
                    {
                        var klncm = new KullanıcıGörünümModel(klnc);

                        //await klncm.VerilerDoldur();

                        Kullanıcılar.Add(klncm);
                    }
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}