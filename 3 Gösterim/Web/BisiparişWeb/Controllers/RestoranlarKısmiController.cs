using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class RestoranlarKısmiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("RestoranlarKısmi/RestoranHizmetSeçildi")]
        public IActionResult RestoranHizmetSeçildi(string dizHizmetDeğer, bool seçildiMi)
        {
            try
            {
                var hizmet = (RestoranHizmetler)long.Parse(dizHizmetDeğer);

                BisiparişWebYardımcı.ŞuAnkiKullanıcıYeniRestoranHizmetler |= seçildiMi ? hizmet : ~hizmet;

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}