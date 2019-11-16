using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class KullanıcılarController : Controller
    {
        [HttpGet, Route("Kullanıcılar/GirişİsimKontrolEt/{girişİsim}")]
        public async Task<IActionResult> GirişİsimKontrolEt(string girişİsim)
        {
            try
            {
                return Json(await Yardımcılar.GüvenlikYardımcı.GirişİsimZatenKullanıldıMı(girişİsim));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}