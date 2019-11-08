using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    public class GirişModel : PageModel
    {
        public async Task OnGet()
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                BisiparişWebYardımcı.ŞuAnkiKullanıcıId = 1; BisiparişWebYardımcı.ŞuAnkiKullanıcıİsim = "Waleed";
                BisiparişWebYardımcı.KullanıcıGirişYaptıMı = true;

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Logged in");

                var prevPage = Request.Headers["Referer"].ToString();

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Returning...");

                LocalRedirect(prevPage);
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }
    }
}