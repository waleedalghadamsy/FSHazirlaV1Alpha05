using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using BisiparişWeb.Yardımcılar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.Restoranlar
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

        public async Task OnGet()
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Into...");

                //İşlemKod = $"{GüvenlikYardımcı.ŞuAnkiKullanıcıId}_{Sunucuİşlem.YeniRestoranKaydetmek}";

                KökDizin = BisiparişWebYardımcı.KökDizin; MevcutHizmetler = "0"; MevcutMutfaklar = "0";

                Restoran = new Restoran() 
                { 
                    AktifMi = true, OnayDurum = OnayDurum.Beklemede,
                    İletişim = new İşyeriİletişim() { Adres = new YerAdres() },
                    OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId
                };

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to prepare...");

                await Yardımcılar.RestoranlarYardımcı.RestoranGerekSinimlerYükle();

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to populate...");

                await GerekliListelerDoldur();

                KaydetmekSonuç = "";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Get done");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                //throw ex;
            }
        }

        public async Task OnPost()
        {
            try
            {
                //var mvctHizmetlerDeğer = (long)0;

                //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"İşlem: '{İşlemKod}'");

                //BisiparişWebYardımcı.SunucuİşlemBaşla(İşlemKod);

                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Coords: '{RstrnKoordiantlar}'");

                Restoran.Tür = (RestoranTürler)SeçilmişTürId; 
                Restoran.Hizmetler = (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), MevcutHizmetler);
                Restoran.Mutfaklar = (Mutfaklar)Enum.Parse(typeof(Mutfaklar), MevcutMutfaklar);

                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"ÇlşmZmn: '{RstrnÇalışmaZamanlamalar}'");

                var clşmZmnKlks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ÇalışmaZamanlamaAlıcı>>(RstrnÇalışmaZamanlamalar);

                foreach (var çlşmZmn in clşmZmnKlks)
                    if (çlşmZmn.HaftaGünSeçildi)
                        Restoran.ÇalışmaZamanlamalar.Add(new ÇalışmaZamanlama()
                        {
                            HaftaGün = çlşmZmn.HaftaGün, Saatten = çlşmZmn.Saatten, Saate = çlşmZmn.Saate
                        });
                    

                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Restoran hizmetler: {Restoran.Hizmetler}");
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Restoran mutfaklar: {Restoran.Mutfaklar}");
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Semt & Mhl: {SeçilmişSemtVeMahId}");

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
                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, 
                    //    $"Pics: {ResimDosyalar.First()} | {ResimDosyalar.Last()}");

                    Restoran.Fotoğraflar = new List<byte[]>();

                    foreach (var rsmDsy in ResimDosyalar)
                        using (var ms = new System.IO.MemoryStream())
                        {
                            await rsmDsy.CopyToAsync(ms); Restoran.Fotoğraflar.Add(ms.ToArray());
                        }
                }

                //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, "Calling YeniRestoranEkle...");

                var sonuç = await Yardımcılar.RestoranlarYardımcı.YeniRestoranEkle(Restoran);

                //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Backk from save: {sonuç.BaşarılıMı}");

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                //await GerekliListelerDoldur();

                //BisiparişWebYardımcı.İşlemlerDurumlar[İşlemKod] = true;

                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Save done: {KaydetmekSonuç}");

                //return KaydetmekSonuç;
            }
            catch (Exception ex)
            {
                KaydetmekSonuç = "<label style='color:red'>Pardon! Kaydederken hata. Lütfen daha sonra tekrar deneyiniz.</label>";

                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                //KaydetmekSonuç = $"<label style='color:red'>EXCEPTION -- {ex.Message}</label>";

                //return KaydetmekSonuç;
            }
        }

        private async Task GerekliListelerDoldur()
        {
            try
            {
                RestoranTürlar = RestoranlarYardımcı.RestoranTürler;
                RestoranOlasıHizmetler = await RestoranlarYardımcı.RestoranHizmetlerSeçeneklerHazırla();
                RestoranOlasıMutfaklar = await RestoranlarYardımcı.RestoranMutfaktlarSeçeneklerHazırla();

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"OlasıHizmetler: {RestoranOlasıHizmetler}");

                İller = await Yardımcılar.İdariBölümlerYardımcı.İllerHazırla();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
    }

    class ÇalışmaZamanlamaAlıcı : ÇalışmaZamanlama
    {
        public bool HaftaGünSeçildi { get; set; }
    }
}