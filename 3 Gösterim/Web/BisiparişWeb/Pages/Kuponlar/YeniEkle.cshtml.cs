using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Muhasebe;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.Kuponlar
{
    public class YeniEkleModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public Kupon Kupon { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                KökDizin = BisiparişWebYardımcı.KökDizin;
                Kupon = new Kupon();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var sonuç = await Yardımcılar.KuponlarYardımcı.YeniKuponEkle(Kupon);

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                await BisiparişWebYardımcı.AyıklamaKaydet(KaydetmekSonuç);

                return Page();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);

                KaydetmekSonuç = "<label style='color:red'>Pardon! Bir hata var.</label>";

                return Page();
            }
        }
    }
}