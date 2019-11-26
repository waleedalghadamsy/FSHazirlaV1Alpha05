using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace BisiparişWeb.Pages
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IMemoryCache cache, ILogger<IndexModel> logger)
        {
            try
            {
                //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index ctor..."));
                //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama,
                //        $"Index -- Session obj: {isSessionAvailable}"));

                _logger = logger;
                
                BisiparişWebYardımcı.MemCache = cache;
                BisiparişWebYardımcı.AppVersion = GetType().Assembly.GetName().Version.ToString();

                BisiparişWebYardımcı.EsansyelVarlıklarYükle();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await BisiparişWebYardımcı.HataKaydet(ex));
            }
        }

        public async Task OnGet()
        {
            try
            {
                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index.Get...");
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Index.Get -- Session obj: {isSessionAvailable}");

                BisiparişWebYardımcı.KökDizin = "http://" + Request.Host.Value;
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                //throw ex;
            }
        }

        //public async Task OnGet()
        //{
        //    try
        //    {
        //        await BisiparişWebYardımcı.GünlükKaydetme(BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Ayıklama, "Into Index...");
        //        BisiparişWebYardımcı.KökDizin = "http://" + Request.Host.Value;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
