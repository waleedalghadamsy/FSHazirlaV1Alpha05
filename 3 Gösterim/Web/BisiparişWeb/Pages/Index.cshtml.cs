using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace BisiparişWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IMemoryCache cache, ILogger<IndexModel> logger)
        {
            try
            {
                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";

                //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index ctor..."));
                //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama,
                //        $"Index -- Session obj: {isSessionAvailable}"));

                _logger = logger;
                
                BisiparişWebYardımcı.MemCache = cache;

                BisiparişWebYardımcı.EsansyelVarlıklarYükle();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
            }
        }

        public async Task OnGet()
        {
            try
            {
                var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into Index.Get...");
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Index.Get -- Session obj: {isSessionAvailable}");

                BisiparişWebYardımcı.KökDizin = "http://" + Request.Host.Value;

                BisiparişWebYardımcı.Session = HttpContext.Session;

                if (!BisiparişWebYardımcı.KullanıcıGirişYaptıMı)
                    LocalRedirect("/SistemGüvenlik/Giriş");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
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
