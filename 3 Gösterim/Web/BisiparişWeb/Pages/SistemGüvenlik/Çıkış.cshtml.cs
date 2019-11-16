using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    public class ÇıkışModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                Task.Run(async () => 
                    await BisiparişWebYardımcı.GünlükKaydetme(BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Hata, ex.Message));
                throw ex;
            }
        }
    }
}