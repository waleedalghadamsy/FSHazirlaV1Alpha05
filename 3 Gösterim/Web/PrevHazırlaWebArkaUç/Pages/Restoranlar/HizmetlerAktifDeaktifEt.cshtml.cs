using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using HazırlaÇekirdek.Valıklar.Erzak;

namespace HazırlaWebArkaUç.Pages.Restoranlar
{
    public class HizmetlerAktifDeaktifEtModel : PageModel
    {
        public string KökDizin { get; set; }
        [BindProperty]
        public List<SelectListItem> KlncRestoranlar { get; set; }
        [BindProperty]
        public int RestoranId { get; set; }
        [BindProperty]
        public string MasaHazırlatVarMı { get; set; }
        [BindProperty]
        public string GelAlVarMı { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                KlncRestoranlar = await GüvenlikYardımcı.ŞimdikiKullanıcıRestoranlarAl();

                KaydetmekSonuç = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var jsnRstrnlr = HazırlaWebYardımcı.MemCache.Get<string>($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr");

                //var jsnRstrnlr = HazırlaWebYardımcı.Session.Keys.Contains($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr")
                //                ? HazırlaWebYardımcı.Session.GetString($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr")
                //                : null;

                await HazırlaWebYardımcı.AyıklamaKaydet($"Into {jsnRstrnlr}");

                if (!string.IsNullOrWhiteSpace(jsnRstrnlr))
                {
                    var msHzrltVar = bool.Parse(MasaHazırlatVarMı); var gelAlVar = bool.Parse(GelAlVarMı);
                    var rstrnlr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsnRstrnlr);
                    var rstrn = rstrnlr.First(r => r.Id == RestoranId);

                    await HazırlaWebYardımcı.AyıklamaKaydet($"Hzmt var: {msHzrltVar} | {gelAlVar}");

                    rstrn.Hizmetler &= msHzrltVar ? RestoranHizmetler.MasaHazırlat : ~RestoranHizmetler.MasaHazırlat;
                    rstrn.Hizmetler &= gelAlVar ? RestoranHizmetler.GelAl : ~RestoranHizmetler.GelAl;

                    await HazırlaWebYardımcı.AyıklamaKaydet($"Yeni hzmt : {rstrn.Hizmetler}");

                    var sonuç = await RestoranlarYardımcı.RestoranHizmetlerDeğiştir(RestoranId, rstrn.Hizmetler);

                    KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);
                }

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
    }
}