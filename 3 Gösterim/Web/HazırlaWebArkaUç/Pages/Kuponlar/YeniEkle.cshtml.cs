using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Muhasebe;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HazırlaWebArkaUç.Yardımcılar;

namespace HazırlaWebArkaUç.Pages.Kuponlar
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
                KökDizin = HazırlaWebYardımcı.KökDizin;
                Kupon = new Kupon();
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
                var sonuç = await Yardımcılar.KuponlarYardımcı.YeniKuponEkle(Kupon);

                KaydetmekSonuç = HazırlaWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);

                await HazırlaWebYardımcı.AyıklamaKaydet(KaydetmekSonuç);

                return Page();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);

                KaydetmekSonuç = "<label style='color:red'>Pardon! Bir hata var.</label>";

                return Page();
            }
        }
    }
}