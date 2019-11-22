using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class SunucuİşlemlerYardımcıController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet, Route("SunucuİşlemlerYardımcı/İşlemBittiMi/{işlemKod}")]
        //public IActionResult İşlemBittiMi(string işlemKod)
        //{
        //    try
        //    {
        //        Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, 
        //            $"{işlemKod} : {BisiparişWebYardımcı.İşlemlerDurumlar[işlemKod]}"));

        //        return Json(BisiparişWebYardımcı.İşlemlerDurumlar[işlemKod]);
        //    }
        //    catch (Exception ex)
        //    {
        //        Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex));
        //        throw ex;
        //    }
        //}
    }
}