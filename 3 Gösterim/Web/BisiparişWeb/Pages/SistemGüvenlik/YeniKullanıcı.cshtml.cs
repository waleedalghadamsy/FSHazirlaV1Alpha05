using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişÇekirdek.Valıklar.İnsanlar;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using BisiparişWeb.Yardımcılar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniKullanıcıModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public Kullanıcı Kullanıcı { get; set; }
        [BindProperty]
        public string KullanıcıİlkAd { get; set; }
        [BindProperty]
        public string KullanıcıSoyAdı { get; set; }
        [BindProperty]
        public string KullanıcıPozisyon { get; set; }
        [BindProperty]
        public List<SelectListItem> KullanıcıRolar { get; set; }
        [BindProperty]
        public string RolSeçildi { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGet()
        {
            try
            {
                KökDizin = BisiparişWebYardımcı.KökDizin;

                Kullanıcı = new Kullanıcı();

                KullanıcıRolar = GüvenlikYardımcı.KullanıcıRolar;

                if (KullanıcıRolar != null && KullanıcıRolar.Any())
                    foreach (var r in KullanıcıRolar)
                        await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"{r.Value} : {r.Text}");
                else
                    await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Roles list empty!!");

                KaydetmekSonuç = "";
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
                var pozsn = new Pozisyon() { Başlık = KullanıcıPozisyon };
                var çlşn = new Çalışan() { İlkAdı = KullanıcıİlkAd, SoyAdı = KullanıcıSoyAdı };

                Kullanıcı.Rol = (KullanıcıRol)Enum.Parse(typeof(KullanıcıRol), RolSeçildi);

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Saving user...");

                var sonuç = await GüvenlikYardımcı.YeniKullanıcıEkle(Kullanıcı);

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