using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HazırlaWebArkaUç.Pages.Menüler
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniEkleModel : PageModel
    {
        public string KökDizin { get; set; }
        [BindProperty]
        public Menü Menü { get; set; }
        [BindProperty]
        public List<SelectListItem> KlncRestoranlar { get; set; }
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
        public string JsonMenüÖğeler { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }
        
        public async Task OnGetAsync()
        {
            try
            {
                KökDizin = HazırlaWebYardımcı.KökDizin;

                Menü = new Menü();

                KlncRestoranlar = await GüvenlikYardımcı.ŞimdikiKullanıcıRestoranlarAl();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {JsonMenüÖğeler}");

                Menü.MenüÖğeler = ÖğelerAyıkla();

                var sonuç = await MenülerYardımcı.YeniMenüEkle(Menü);

                KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                return Page();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        private List<MenüÖğe> ÖğelerAyıkla()
        {
            List<MenüÖğe> öğlr = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(JsonMenüÖğeler))
                {
                    var jsnÖğlr = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonMenüÖğeler) as Newtonsoft.Json.Linq.JArray;

                    öğlr = new List<MenüÖğe>();

                    foreach (var jsnÖğe in jsnÖğlr)
                    {
                        var props = new List<Newtonsoft.Json.Linq.JProperty>();

                        foreach (var aProp in jsnÖğe.Children())
                            props.Add(aProp as Newtonsoft.Json.Linq.JProperty);

                        var p0 = props[0] != null ? props[0].Value.ToString() : "(Wrong!!)";
                        var p2 = props[2] != null ? props[2].Value.ToString() : "(Wrong!!)";

                        Task.Run(async () =>
                        {
                            await HazırlaWebYardımcı.AyıklamaKaydet($"Name: {p0}");
                            await HazırlaWebYardımcı.AyıklamaKaydet($"Tür: {p2}");
                        });

                        var adProp = props[0]; var türProp = props[1]; var fytProp = props[2]; var btmProp = props[3];

                        //var adProp = jsnÖğe["Menü Öğe Ad"] as Newtonsoft.Json.Linq.JProperty;
                        //var türProp = jsnÖğe["Öğe Tür"] as Newtonsoft.Json.Linq.JProperty;
                        //var fytProp = jsnÖğe["Fiyat"] as Newtonsoft.Json.Linq.JProperty;
                        //var btmProp = jsnÖğe["Betimleme"] as Newtonsoft.Json.Linq.JProperty;

                        öğlr.Add(new MenüÖğe()
                        {
                             Ad = adProp.Value.ToString(),
                             Tür = türProp.Value.ToString().Equals("Yemek") ? SiparişÖğeTür.Yemek : SiparişÖğeTür.İçecek,
                             Fiyat = float.Parse(fytProp.Value.ToString()),
                             Betimleme = btmProp.Value.ToString(),
                             SistemDurum = VarlıkSistemDurum.Aktif,
                             OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
                             Oluşturulduğunda = DateTime.Now
                        });
                    }
                }

                return öğlr;
            }
            catch (Exception ex)
            {
                Task.Run(async () => await HazırlaWebYardımcı.HataKaydet(ex));
                throw;
            }
        }
    }
}