using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.Kafeler
{
    public class YeniEkleModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public string İlİlçelerCtrlAction { get; set; }
        [BindProperty]
        public Kafe Kafe { get; set; }
        [BindProperty]
        public List<SelectListItem> İller { get; set; }
        [BindProperty]
        public int SeçilmişİlPlaka { get; set; }
        [BindProperty]
        public int SeçilmişİlçeId { get; set; }
        [BindProperty]
        public int SeçilmişSemtId { get; set; }
        [BindProperty]
        public int SeçilmişMahalleId { get; set; }
        [BindProperty]
        public string KafeTelefonlar { get; set; }
        [BindProperty]
        public string KafeEpostalar { get; set; }
        [BindProperty]
        public List<IFormFile> ResimDosyalar { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGet()
        {
            try
            {
                KökDizin = BisiparişWebYardımcı.KökDizin;

                Kafe = new Kafe() { İletişim = new İşyeriİletişim() { Adres = new YerAdres() } };

                await BisiparişWebYardımcı.KafeGerekSinimlerYükle();

                GerekliListelerDoldur();

                KaydetmekSonuç = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task OnPost()
        {
            try
            {
                Kafe.İletişim.Adres.İlId = 34; Kafe.İletişim.Adres.İlçeId = SeçilmişİlçeId;
                Kafe.İletişim.Adres.SemtId = SeçilmişSemtId; Kafe.İletişim.Adres.MahalleId = SeçilmişMahalleId;

                if (ResimDosyalar != null)
                {
                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, 
                    //    $"Pics: {ResimDosyalar.First()} | {ResimDosyalar.Last()}");

                    Kafe.Fotoğraflar = new List<byte[]>();

                    foreach (var rsmDsy in ResimDosyalar)
                        using (var ms = new System.IO.MemoryStream())
                        {
                            await rsmDsy.CopyToAsync(ms); Kafe.Fotoğraflar.Add(ms.ToArray());
                        }
                }

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Calling YeniRestoranEkle...");

                var sonuç = await BisiparişWebYardımcı.YeniKafeEkle(Kafe);

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                GerekliListelerDoldur();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);

                //KaydetmekSonuç = "<label style='color:red'>Pardon! Kaydederken hata. Lütfen daha sonra tekrar deneyiniz.</label>";
                KaydetmekSonuç = $"<label style='color:red'>EXCEPTION -- {ex.Message}</label>";
            }
        }

        private void GerekliListelerDoldur()
        {
            try
            {
                İller = BisiparişWebYardımcı.İller;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}