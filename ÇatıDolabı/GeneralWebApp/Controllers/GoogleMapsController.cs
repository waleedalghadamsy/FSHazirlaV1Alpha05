using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeneralWebApp.Controllers
{
    public class GoogleMapsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ExampleAction()
        {
            try
            {
                await Task.Run(() => { });

                return Json("It is working");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet, Route("GoogleMaps/GetCoords/{url}")]
        public async Task<IActionResult> GetCoords(string url)
        {
            try
            {
                using (var req = new System.Net.Http.HttpClient())
                {
                    var resp = await req.GetAsync(url);

                    var strUrl = resp.RequestMessage.RequestUri.AbsoluteUri;
                    var atLoc = strUrl.IndexOf('@'); var zLoc = strUrl.Substring(atLoc).IndexOf('z');
                    var strCoords = strUrl.Substring(atLoc + 1, zLoc);
                    var coords = strCoords.Split(new char[] { ',' });

                    return Json(coords);
                }
            }
            catch (Exception ex)
            {
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                return Content("");
            }
        }
    }
}