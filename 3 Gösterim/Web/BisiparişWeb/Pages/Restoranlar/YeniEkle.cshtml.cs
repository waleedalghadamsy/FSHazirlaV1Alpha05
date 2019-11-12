using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
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
        public int SeçilmişİlId { get; set; }
        [BindProperty]
        public int SeçilmişİlçeId { get; set; }
        [BindProperty]
        public int SeçilmişSemtId { get; set; }
        [BindProperty]
        public int SeçilmişMahalleId { get; set; }
        [BindProperty]
        public int SeçilmişTürId { get; set; }
        [BindProperty]
        public string MevcutHizmetler { get; set; }
        [BindProperty]
        public string RestoranTelefonlar { get; set; }
        [BindProperty]
        public string RestoranEpostalar { get; set; }
        [BindProperty]
        public List<IFormFile> ResimDosyalar { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGet()
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                KökDizin = BisiparişWebYardımcı.KökDizin; MevcutHizmetler = "0";

                Restoran = new Restoran() 
                { 
                    AktifMi = true, OnayDurum = OnayDurum.Bekleyen,
                    İletişim = new İşyeriİletişim() { Adres = new YerAdres() },
                    OluşturuKimsiId = BisiparişWebYardımcı.ŞuAnkiKullanıcıId
                };

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to prepare...");

                await BisiparişWebYardımcı.RestoranGerekSinimlerYükle();

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Going to populate...");

                await GerekliListelerDoldur();

                KaydetmekSonuç = "";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Get done");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                //throw ex;
            }
        }

        public async Task OnPost()
        {
            try
            {
                //var mvctHizmetlerDeğer = (long)0;

                Restoran.Tür = (RestoranTürler)SeçilmişTürId; 
                Restoran.Hizmetler = (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), MevcutHizmetler);

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Restoran hizmetler: {Restoran.Hizmetler}");

                Restoran.İletişim.Adres.İlId = SeçilmişİlId; Restoran.İletişim.Adres.İlçeId = SeçilmişİlçeId;
                Restoran.İletişim.Adres.SemtId = SeçilmişSemtId; Restoran.İletişim.Adres.MahalleId = SeçilmişMahalleId;

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

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Calling YeniRestoranEkle...");

                var sonuç = await BisiparişWebYardımcı.YeniRestoranEkle(Restoran);

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                await GerekliListelerDoldur();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);

                KaydetmekSonuç = "<label style='color:red'>Pardon! Kaydederken hata. Lütfen daha sonra tekrar deneyiniz.</label>";
                //KaydetmekSonuç = $"<label style='color:red'>EXCEPTION -- {ex.Message}</label>";
            }
        }

        private async Task GerekliListelerDoldur()
        {
            try
            {
                RestoranTürlar = BisiparişWebYardımcı.RestoranTürler;
                RestoranOlasıHizmetler = await BisiparişWebYardımcı.RestoranHizmetlerSeçeneklerHazırla();

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"OlasıHizmetler: {RestoranOlasıHizmetler}");

                İller = await BisiparişWebYardımcı.İllerHazırla();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

    }
}