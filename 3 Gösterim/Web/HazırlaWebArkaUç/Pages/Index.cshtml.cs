using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using HazırlaWebArkaUç.Yardımcılar;

namespace HazırlaWebArkaUç.Pages
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IMemoryCache cache, ILogger<IndexModel> logger)
        {
            try
            {
                //Task.Run(async () => await HazırlaWebYardımcı.AyıklamaKaydet("Into Index ctor..."));
                //Task.Run(async () => await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama,
                //        $"Index -- Session obj: {isSessionAvailable}"));

                _logger = logger;
                
                HazırlaWebYardımcı.MemCache = cache;
                HazırlaWebYardımcı.AppVersion = GetType().Assembly.GetName().Version.ToString();

                HazırlaWebYardımcı.EsansyelVarlıklarYükle();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await HazırlaWebYardımcı.HataKaydet(ex));
            }
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                HazırlaWebYardımcı.KökDizin = "http://" + Request.Host.Value;

                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";
                //var isAppSessionAvailable = HazırlaWebYardımcı.Session != null ? "OK" : "(NULL)";

                //await HazırlaWebYardımcı.AyıklamaKaydet("Into Index.Get...");
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Index.Get -- Session obj: {isSessionAvailable}");
                //await HazırlaWebYardımcı.AyıklamaKaydet($"App Session obj: {isAppSessionAvailable}");

                if (HttpContext.Session == null || HazırlaWebYardımcı.Session == null
                                                /*|| Yardımcılar.GüvenlikYardımcı.ŞimdikiKullanıcı == null*/)
                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Redirecting to Login...");
                    return LocalRedirect(Uri.EscapeUriString("/SistemGüvenlik/Giriş?ReturnUrl=/"));
                else
                    return Page();
                
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                
                return Page();
                //throw ex;
            }
        }

        //public async Task OnGet()
        //{
        //    try
        //    {
        //        await HazırlaWebYardımcı.GünlükKaydetme(HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Ayıklama, "Into Index...");
        //        HazırlaWebYardımcı.KökDizin = "http://" + Request.Host.Value;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
