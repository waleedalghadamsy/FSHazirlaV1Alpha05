using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HazırlaWebArkaUç.Pages.Kategoriler
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniMenüKategoriEkleModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public Kategori Kategori { get; set; }
        [BindProperty]
        public List<SelectListItem> KlncRestoranlar { get; set; }
        [BindProperty]
        public int RestoranSeçildi { get; set; }
        [BindProperty]
        public string YeniKategoriler { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (HttpContext.Session != null)
                {
                    KökDizin = HazırlaWebYardımcı.KökDizin;

                    KlncRestoranlar = await GüvenlikYardımcı.ŞimdikiKullanıcıRestoranlarListe();

                    Kategori = new Kategori();

                    KaydetmekSonuç = "";

                    return Page();
                }
                else
                    return LocalRedirect(Uri.EscapeUriString("/SistemGüvenlik/Giriş?ReturnUrl=/"));
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var kategoriler = new List<Kategori>();// KategorilerAyıkla();
                
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Saving {kategoriler.Count} categories");

                var sonuç = await MenülerYardımcı.YeniKategorilerEkle(kategoriler);

                KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);
                
                ModelState.Remove("KaydetmekSonuç");

                return Page();
            }
            catch (Exception ex)
            {
                KaydetmekSonuç = "<label style='color:red'>Pardon! Kaydederken hata. Lütfen daha sonra tekrar deneyiniz.</label>";

                await HazırlaWebYardımcı.HataKaydet(ex);

                ModelState.Remove("KaydetmekSonuç");

                return Page();
            }
        }

        //private List<Kategori> KategorilerAyıkla()
        //{
        //    List<Kategori> ktgrlr = null;

        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(YeniKategoriler))
        //        {
        //            ktgrlr = new List<Kategori>();

        //            var jsnKatgrlr = Newtonsoft.Json.JsonConvert.DeserializeObject(YeniKategoriler) as Newtonsoft.Json.Linq.JArray;
        //            Kategori birKat = null;

        //            foreach (var jsnKtg in jsnKatgrlr)
        //            {
        //                var ktProp = jsnKtg.First as Newtonsoft.Json.Linq.JProperty;
        //                var alktProp = jsnKtg.Last as Newtonsoft.Json.Linq.JProperty;
        //                var katAd = ktProp.Value.ToString();
        //                var katVar = ktgrlr.FirstOrDefault(k => k.Ad.Equals(katAd));

        //                if (katVar == null)
        //                {
        //                    birKat = new Kategori()
        //                    {
        //                        Ad = katAd,
        //                        RestoranId = RestoranSeçildi,
        //                        SistemDurum = VarlıkSistemDurum.Aktif,
        //                        OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
        //                        Oluşturulduğunda = DateTime.Now,
        //                        AltKategoriler = new List<Kategori>()
        //                    };

        //                    ktgrlr.Add(birKat);
        //                }
        //                else
        //                    birKat = katVar;

        //                if (alktProp.Value != null && !string.IsNullOrWhiteSpace(alktProp.Value.ToString()))
        //                    birKat.AltKategoriler.Add(
        //                        new Kategori()
        //                        {
        //                            Ad = alktProp.Value.ToString(),
        //                            RestoranId = RestoranSeçildi,
        //                            SistemDurum = VarlıkSistemDurum.Aktif,
        //                            OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
        //                            Oluşturulduğunda = DateTime.Now
        //                        });
        //            }
        //        }

        //        return ktgrlr;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}