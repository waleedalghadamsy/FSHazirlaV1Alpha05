using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
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
        public Menü Menü { get; set; }
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
        
        public async Task OnGet()
        {
            try
            {
                Menü = new Menü();

                var rstrnlr = await Yardımcılar.RestoranlarYardımcı.RestoranlarAl();

                if (rstrnlr != null && rstrnlr.Any())
                {
                    Restoranlar = new List<SelectListItem>();

                    foreach (var r in rstrnlr)
                        Restoranlar.Add(new SelectListItem(r.İsim, r.Id.ToString()));
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public async Task OnPost()
        {
            try
            {
                var sonuç = await Yardımcılar.MenülerYardımcı.YeniMenüEkle(Menü);

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }
    }
}