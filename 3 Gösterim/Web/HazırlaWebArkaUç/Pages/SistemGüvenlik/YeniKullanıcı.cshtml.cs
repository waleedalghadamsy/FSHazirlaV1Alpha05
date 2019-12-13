using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.Güvenlik;
using HazırlaÇekirdek.Valıklar.İnsanlar;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HazırlaWebArkaUç.Pages.SistemGüvenlik
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniKullanıcıModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public Kullanıcı Kullanıcı { get; set; }
        //[BindProperty]
        //public int? ŞmdkKlncRestoranId { get; set; }
        [BindProperty]
        public string ŞmdkKlncRstrnKlncıMı { get; set; }
        [BindProperty]
        public List<SelectListItem> KlncRestoranlar { get; set; }
        [BindProperty]
        public string KullanıcıAdSoyAd { get; set; }
        [BindProperty]
        public string KullanıcıCinsiyet { get; set; }
        [BindProperty]
        public string KullanıcıPozisyon { get; set; }
        [BindProperty]
        public List<SelectListItem> KullanıcıRolar { get; set; }
        [BindProperty]
        public string RolSeçildi { get; set; }
        [BindProperty]
        public int RstrnSeçildiId { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                KökDizin = HazırlaWebYardımcı.KökDizin;

                Kullanıcı = new Kullanıcı();

                KlncRestoranlar = await GüvenlikYardımcı.ŞimdikiKullanıcıRestoranlarAl();

                //ŞmdkKlncRestoranId = await GüvenlikYardımcı.ŞimdikiKullanıcıRestoranIdAl();

                var şmdkKlncRol = GüvenlikYardımcı.ŞimdikiKullanıcı.Rol;

                ŞmdkKlncRstrnKlncıMı = (GüvenlikYardımcı.ŞimdikiKullanıcıİşletmeYöneticiMi 
                                        || GüvenlikYardımcı.ŞimdikiKullanıcıİşletmeKullanıcıMı).ToString();

                await HazırlaWebYardımcı.AyıklamaKaydet($"Is admin: {ŞmdkKlncRstrnKlncıMı}");

                KullanıcıRolar = GüvenlikYardımcı.KullanıcıRolar;

                //if (KullanıcıRolar != null && KullanıcıRolar.Any())
                //    foreach (var r in KullanıcıRolar)
                //        await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"{r.Value} : {r.Text}");
                //else
                //    await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Roles list empty!!");

                KaydetmekSonuç = "";
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            İcraSonuç sonuç = null;

            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet("Into...");

                //var pozsn = new Pozisyon() { Başlık = Kullanıcı.Pozisyon };
                //var ikiPart = Kullanıcı.AdSoyad.Split(new char[] { ' ' });
                //var soyad = new System.Text.StringBuilder("");

                //if (ikiPart.Length > 1)
                //    for (int i = 1; i < ikiPart.Length; i++)
                //        soyad.Append(ikiPart[i]);

                //var çlşn = new Çalışan() { İlkAdı = ikiPart[0], SoyAdı = soyad.ToString() };

                //Kullanıcı.AdSoyad = KullanıcıAdSoyAd; 
                await HazırlaWebYardımcı.AyıklamaKaydet(KullanıcıCinsiyet);

                Kullanıcı.Cinsiyet = (Cinsiyet)Enum.Parse(typeof(Cinsiyet), KullanıcıCinsiyet);
                Kullanıcı.Rol = (KullanıcıRol)Enum.Parse(typeof(KullanıcıRol), RolSeçildi);

                await HazırlaWebYardımcı.AyıklamaKaydet("Saving user...");

                if (Kullanıcı.Rol == KullanıcıRol.SistemYönetici || Kullanıcı.Rol == KullanıcıRol.MüşteriDestekTemsilci)
                    sonuç = await GüvenlikYardımcı.YeniKullanıcıEkle(Kullanıcı);
                else if (Kullanıcı.Rol == KullanıcıRol.İşletmeYönetici || Kullanıcı.Rol == KullanıcıRol.İşletmeKullanıcı)
                    sonuç = await GüvenlikYardımcı.YeniRestoranKullanıcıEkle(Kullanıcı, RstrnSeçildiId);

                await HazırlaWebYardımcı.AyıklamaKaydet("Back from save");

                KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                await HazırlaWebYardımcı.AyıklamaKaydet(KaydetmekSonuç);

                ModelState.Remove("KaydetmekSonuç");

                return Page();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);

                KaydetmekSonuç = "<label style='color:red'>Pardon! Bir hata var.</label>";

                return Page();
            }
        }
    }
}