using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HazırlaWebArkaUç.Yardımcılar;
using HazırlaÇekirdek.Valıklar.Esansiyel;

namespace HazırlaWebArkaUç.Pages.Restoranlar
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DeğiştirModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public string İlİlçelerCtrlAction { get; set; }
        [BindProperty]
        public Restoran Restoran { get; set; }
        [BindProperty]
        public List<SelectListItem> İller { get; set; }
        [BindProperty]
        public List<SelectListItem> RestoranTürlar { get; set; }
        [BindProperty]
        public string RestoranOlasıHizmetler { get; set; }
        [BindProperty]
        public string RestoranOlasıMutfaklar { get; set; }
        [BindProperty]
        public string RstrnÇalışmaZamanlamalar { get; set; }
        [BindProperty]
        public int SeçilmişİlId { get; set; }
        [BindProperty]
        public int SeçilmişİlçeId { get; set; }
        //[BindProperty]
        //public int SeçilmişSemtId { get; set; }
        //[BindProperty]
        //public int SeçilmişMahalleId { get; set; }
        [BindProperty]
        public string SeçilmişSemtVeMahId { get; set; }
        [BindProperty]
        public int SeçilmişTürId { get; set; }
        [BindProperty]
        public string MevcutHizmetler { get; set; }
        [BindProperty]
        public string MevcutMutfaklar { get; set; }
        [BindProperty]
        public string RestoranTelefonlar { get; set; }
        [BindProperty]
        public string RestoranEpostalar { get; set; }
        [BindProperty]
        public List<IFormFile> ResimDosyalar { get; set; }
        [BindProperty]
        public string RstrnKoordiantlar { get; set; }
        [BindProperty]
        public string DeğiştirmekSonuç { get; set; }

        public async Task OnGetAsync(int rstrnId)
        {
            try
            {
                KökDizin = HazırlaWebYardımcı.KökDizin; MevcutHizmetler = "0"; MevcutMutfaklar = "0";

                Restoran = await RestoranlarYardımcı.RestoranAl(rstrnId);

                await GerekliListelerDoldur();
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
                Restoran.Tür = (RestoranTürler)SeçilmişTürId;
                Restoran.Hizmetler = (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), MevcutHizmetler);
                Restoran.Mutfaklar = (Mutfaklar)Enum.Parse(typeof(Mutfaklar), MevcutMutfaklar);

                if (!string.IsNullOrWhiteSpace(RstrnÇalışmaZamanlamalar))
                {
                    Restoran.ÇalışmaZamanlamalar =
                        System.Text.Json.JsonSerializer.Deserialize<List<ÇalışmaZamanlama>>(RstrnÇalışmaZamanlamalar,
                                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Found: {Restoran.ÇalışmaZamanlamalar.Count} weekdays");
                }

                var semtId = 0; var mhlId = 0;

                if (SeçilmişSemtVeMahId.Contains("_"))
                {
                    var ikiKod = SeçilmişSemtVeMahId.Split(new char[] { '_' });
                    semtId = int.Parse(ikiKod[0]); mhlId = int.Parse(ikiKod[1]);
                }
                else
                    semtId = int.Parse(SeçilmişSemtVeMahId);

                Restoran.İletişim.Adres.İlId = SeçilmişİlId; Restoran.İletişim.Adres.İlçeId = SeçilmişİlçeId;
                Restoran.İletişim.Adres.SemtId = semtId; Restoran.İletişim.Adres.MahalleId = mhlId;

                if (ResimDosyalar != null)
                {
                    Restoran.Fotoğraflar = new List<byte[]>();

                    foreach (var rsmDsy in ResimDosyalar)
                        using (var ms = new System.IO.MemoryStream())
                        {
                            await rsmDsy.CopyToAsync(ms); Restoran.Fotoğraflar.Add(ms.ToArray());
                        }
                }

                var sonuç = await RestoranlarYardımcı.RestoranDeğiştir(Restoran);

                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Backk from save: {sonuç.BaşarılıMı}");

                DeğiştirmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Değiştirmek, sonuç);

                //await GerekliListelerDoldur();

                //HazırlaWebYardımcı.İşlemlerDurumlar[İşlemKod] = true;

                await HazırlaWebYardımcı.AyıklamaKaydet($"Modification done: {DeğiştirmekSonuç}");

                ModelState.Remove("DeğiştirmekSonuç");

                return Page();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task GerekliListelerDoldur()
        {
            try
            {
                RestoranTürlar = RestoranlarYardımcı.RestoranTürler;
                RestoranOlasıHizmetler = await RestoranlarYardımcı.RestoranHizmetlerSeçeneklerHazırla();
                RestoranOlasıMutfaklar = await RestoranlarYardımcı.RestoranMutfaktlarSeçeneklerHazırla();

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"OlasıHizmetler: {RestoranOlasıHizmetler}");

                İller = await İdariBölümlerYardımcı.İllerHazırla();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}