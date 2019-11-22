using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class GoogleMapsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("GoogleMaps/KoordinatlarAl")]
        public async Task<IActionResult> KoordinatlarAl(string url)
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Into... Url:{url}");

                using (var req = new System.Net.Http.HttpClient())
                {
                    var resp = await req.GetAsync(url);

                    var strUrl = resp.RequestMessage.RequestUri.AbsoluteUri;
                    var atLoc = strUrl.IndexOf('@'); var zLoc = strUrl.Substring(atLoc).IndexOf('z');
                    var strCoords = strUrl.Substring(atLoc + 1, zLoc);
                    var coords = strCoords.Split(new char[] { ',' });

                    await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Uyarı, $"Coords: {coords[0]}, {coords[1]}");

                    return Json(coords);
                    //return Json($"{coords[0]},{coords[1]}");// coords);
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                return Content("");
            }
        }

        [HttpGet, Route("GoogleMaps/Example")]
        public async Task<IActionResult> Example()
        {
            await Task.Run(() => { });
            return Json("Working");
        }

        [HttpGet, Route("GoogleMaps/AnotherExample")]
        public async Task<IActionResult> AnotherExample(string str)
        {
            await Task.Run(() => { });
            return Json($"How are you {str}");
        }
    }
}