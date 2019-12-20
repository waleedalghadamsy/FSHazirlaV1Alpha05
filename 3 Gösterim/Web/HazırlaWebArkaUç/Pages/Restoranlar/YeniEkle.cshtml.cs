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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HazırlaWebArkaUç.Pages.Restoranlar
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniEkleModel : PageModel
    {
        //[BindProperty]
        //public string İşlemKod { get; set; }
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
        public string KaydetmekSonuç { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (HttpContext.Session != null)
                {
                    //await HazırlaWebYardımcı.AyıklamaKaydet("Into...");

                    //İşlemKod = $"{GüvenlikYardımcı.ŞuAnkiKullanıcıId}_{Sunucuİşlem.YeniRestoranKaydetmek}";

                    KökDizin = HazırlaWebYardımcı.KökDizin; MevcutHizmetler = "0"; MevcutMutfaklar = "0";

                    Restoran = new Restoran()
                    {
                        SistemDurum = VarlıkSistemDurum.Aktif,
                        OnayDurum = OnayDurum.Beklemede,
                        İletişim = new İşyeriİletişim() { Adres = new YerAdres() },
                        OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId
                    };

                    //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to prepare...");

                    await RestoranlarYardımcı.RestoranGerekSinimlerYükle();

                    //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to populate...");

                    await GerekliListelerDoldur();

                    KaydetmekSonuç = "";

                    //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Get done");

                    return Page();
                }
                else
                    return LocalRedirect(Uri.EscapeUriString("/SistemGüvenlik/Giriş?ReturnUrl=/"));
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);

                return Page();
                //throw ex;
            }
        }

        public async Task OnPostAsync()
        {
            const long MAKSFOTODOSYABOYUT = 50 * 1024;

            try
            {
                //var mvctHizmetlerDeğer = (long)0;

                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"İşlem: '{İşlemKod}'");

                //HazırlaWebYardımcı.SunucuİşlemBaşla(İşlemKod);

                await HazırlaWebYardımcı.AyıklamaKaydet($"Coords: '{RstrnKoordiantlar}'");

                Restoran.Tür = (RestoranTürler)SeçilmişTürId; 
                Restoran.Hizmetler = (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), MevcutHizmetler);
                Restoran.Mutfaklar = (Mutfaklar)Enum.Parse(typeof(Mutfaklar), MevcutMutfaklar);

                //await HazırlaWebYardımcı.AyıklamaKaydet($"ÇlşmZmn: '{RstrnÇalışmaZamanlamalar}'");

                if (!string.IsNullOrWhiteSpace(RstrnÇalışmaZamanlamalar))
                {
                    //var clşmZmnKlks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ÇalışmaZamanlamaAlıcı>>(RstrnÇalışmaZamanlamalar);
                    Restoran.ÇalışmaZamanlamalar =
                        System.Text.Json.JsonSerializer.Deserialize<List<ÇalışmaZamanlama>>(RstrnÇalışmaZamanlamalar,
                                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Found: {Restoran.ÇalışmaZamanlamalar.Count} weekdays");
                }

                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Restoran hizmetler: {Restoran.Hizmetler}");
                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Restoran mutfaklar: {Restoran.Mutfaklar}");
                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Semt & Mhl: {SeçilmişSemtVeMahId}");

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

                if (ResimDosyalar != null && ResimDosyalar.Any())
                {
                    var elliKFotolar = ResimDosyalar.Where(rd => rd.Length <= MAKSFOTODOSYABOYUT);

                    if (elliKFotolar != null && elliKFotolar.Any())
                    {
                        Restoran.Fotoğraflar = new List<byte[]>();

                        foreach (var rsmDsy in ResimDosyalar)
                            using (var ms = new System.IO.MemoryStream())
                            {
                                await rsmDsy.CopyToAsync(ms); Restoran.Fotoğraflar.Add(ms.ToArray());
                            }
                    }
                }

                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, "Calling YeniRestoranEkle...");

                var sonuç = await Yardımcılar.RestoranlarYardımcı.YeniRestoranEkle(Restoran);

                //await HazırlaWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Backk from save: {sonuç.BaşarılıMı}");

                KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                //await GerekliListelerDoldur();

                //HazırlaWebYardımcı.İşlemlerDurumlar[İşlemKod] = true;

                HazırlaWebYardımcı.Session.SetString("KydtSnc", KaydetmekSonuç);

                //await HazırlaWebYardımcı.AyıklamaKaydet($"Save done: {KaydetmekSonuç}");

                //ModelState.Remove("KaydetmekSonuç");

                //return Page();
            }
            catch (Exception ex)
            {
                KaydetmekSonuç = "<label style='color:red'>Pardon! Kaydederken hata. Lütfen daha sonra tekrar deneyiniz.</label>";

                await HazırlaWebYardımcı.HataKaydet(ex);
                
                ModelState.Remove("KaydetmekSonuç");

                //return Page();
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

                İller = await Yardımcılar.İdariBölümlerYardımcı.İllerHazırla();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public ActionResult OnGetKaydetSonucu()
        {
            try
            {
                var msj = HazırlaWebYardımcı.Session.GetString("KydtSnc");

                Task.Run(async () => await HazırlaWebYardımcı.AyıklamaKaydet("Into..."));
                Task.Run(async () => await HazırlaWebYardımcı.AyıklamaKaydet($"{msj}"));

                return new JsonResult(new List<string>() { msj });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await HazırlaWebYardımcı.HataKaydet(ex));

                return new JsonResult("");
                //throw;
            }
        }
    }

    //class ÇalışmaZamanlamaAlıcı : ÇalışmaZamanlama
    //{
    //    public bool HaftaGünSeçildi { get; set; }
    //}
}