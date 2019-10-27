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

namespace BisiparişWeb.Pages.Restoranlar
{
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
        public int SeçilmişİlPlaka { get; set; }
        [BindProperty]
        public int SeçilmişİlçeId { get; set; }
        [BindProperty]
        public int SeçilmişSemtId { get; set; }
        [BindProperty]
        public int SeçilmişMahalleId { get; set; }
        [BindProperty]
        public int SeçilmişTürId { get; set; }
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
                KökDizin = BisiparişWebYardımcı.KökDizin;

                Restoran = new Restoran() { İletişim = new İşyeriİletişim() { Adres = new YerAdres() } };

                await BisiparişWebYardımcı.RestoranGerekSinimlerYükle();

                GerekliListelerDoldur();

                KaydetmekSonuç = "";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task OnPost()
        {
            try
            {
                Restoran.Tür = (RestoranTür)SeçilmişTürId;

                Restoran.İletişim.Adres.İlId = 34; Restoran.İletişim.Adres.İlçeId = SeçilmişİlçeId;
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
                RestoranTürlar = BisiparişWebYardımcı.RestoranTürlar;
                İller = BisiparişWebYardımcı.İller;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}