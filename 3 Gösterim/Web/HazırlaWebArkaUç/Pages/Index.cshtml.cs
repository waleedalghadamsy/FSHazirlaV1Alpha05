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
                //Task.Run(async () => await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index ctor..."));
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

        public async Task OnGet()
        {
            try
            {
                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index.Get...");
                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Index.Get -- Session obj: {isSessionAvailable}");

                HazırlaWebYardımcı.KökDizin = "http://" + Request.Host.Value;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
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
