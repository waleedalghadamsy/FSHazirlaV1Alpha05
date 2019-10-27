using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişWeb.Modeller.Restoranlar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.Restoranlar
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<RestoranGörünümModel> Restoranlar { get; set; }

        public async Task OnGet()
        {
            try
            {
                var rstrnlr = await BisiparişWebYardımcı.RestoranlarAl();

                if (rstrnlr != null && rstrnlr.Any())
                {
                    Restoranlar = new List<RestoranGörünümModel>();

                    foreach (var rst in rstrnlr)
                    {
                        var rstgm = new RestoranGörünümModel(rst);

                        await rstgm.VerilerDoldur();

                        Restoranlar.Add(rstgm);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}