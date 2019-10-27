using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişWeb.Modeller.Kafeler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.Kafeler
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<KafeGörünümModel> Kafeler { get; set; }

        public async Task OnGet()
        {
            try
            {
                var kaflr = await BisiparişWebYardımcı.KafelerAl();

                if (kaflr != null && kaflr.Any())
                {
                    Kafeler = new List<KafeGörünümModel>();

                    foreach (var kf in kaflr)
                    {
                        var kfgm = new KafeGörünümModel(kf);

                        await kfgm.VerilerDoldur();

                        Kafeler.Add(kfgm);
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