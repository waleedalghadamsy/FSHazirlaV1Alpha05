using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Modeller.Restoranlar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HazırlaWebArkaUç.Yardımcılar;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using System.Text;

namespace HazırlaWebArkaUç.Pages.Restoranlar
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public List<RestoranGörünümModel> Restoranlar { get; set; }
        [BindProperty]
        public string GerekliRestoranlar { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (HttpContext.Session != null)
                {
                    KökDizin = HazırlaWebYardımcı.KökDizin;

                    Restoranlar = new List<RestoranGörünümModel>();

                    return Page();
                }
                else
                    return LocalRedirect(Uri.EscapeUriString("/SistemGüvenlik/Giriş?ReturnUrl=/"));
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> OnGetRestoranlarAsync(string grkliRstrnlr)
        {
            List<Restoran> birazRstrnlr = null;
            StringBuilder tBodySb = new StringBuilder("");

            try
            {
                switch(grkliRstrnlr)
                {
                    case "1": //Ona Beklemde
                        birazRstrnlr = await RestoranlarYardımcı.ŞimdikiKullanıcıRestoranlarAl(OnayDurum.Beklemede);
                        break;
                    case "2": //Onaylı
                        birazRstrnlr = await RestoranlarYardımcı.ŞimdikiKullanıcıRestoranlarAl(OnayDurum.Onaylı);
                        break;
                    case "3": //Hepsi
                        birazRstrnlr = await RestoranlarYardımcı.ŞimdikiKullanıcıRestoranlarAl();
                        break;
                }

                if (birazRstrnlr != null && birazRstrnlr.Any())
                {
                    //Restoranlar = new List<RestoranGörünümModel>();

                    foreach (var rst in birazRstrnlr)
                    {
                        var rstgm = new RestoranGörünümModel(rst);

                        await rstgm.VerilerDoldur();

                        //Restoranlar.Add(rstgm);
                        tBodySb.AppendLine($"<tr>"
                            + $"<td>{rstgm.DizDurum}</td><td>{rstgm.İsim}</td><td>{rstgm.DizTür}</td>"
                            + $"<td>{rstgm.DizHizmetler}</td><td>{rstgm.DizMutfaklar}</td><td>{rstgm.MenüSayısı}</td>"
                            + $"<td><img src=\"{rstgm.ResimKaynak}\" width=\"50\" height=\"50\" /></td>"
                            + $"<td>{rstgm.İlAd}</td><td>{rstgm.İlçeAd}</td><td>{rstgm.SemtAd}</td>"
                            + $"<td><a asp-page=\"/Restoranlar/Değiştir\" asp-route-id=\"{rstgm.Id}\">"
                            + "<span class=\"fa fa-pencil\"/></a></td></tr>");
                    }
                }

                return new JsonResult(tBodySb.ToString());
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}