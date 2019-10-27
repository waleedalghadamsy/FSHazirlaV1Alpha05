using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OlayGünlüğüHizmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GünlükçüController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [HttpPost]
        public async Task<ActionResult> Post(Günlük günlük)
        {
            string tracer = "";

            try
            {
                //tracer = "[1] | " + jsonGünlük;
                //var günlük = Newtonsoft.Json.JsonConvert.DeserializeObject<Günlük>(jsonGünlük);
                //tracer = "[2]";
                //tracer = "[3]";
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(günlük);
                //tracer = "[4]";

                return Ok();// tracer);// + " | " + dbResult);
            }
            catch (Exception ex)
            {
                return Content(tracer + " | CATCH-ERROR: " + ex.Message);
                //throw;
            }
        }

        //[ActionName("OnlyForTest")]
        //[HttpPost]
        //public async Task<ActionResult> PostOnlyForTest(string message)
        //{
        //    try
        //    {
        //        var şimdi = DateTime.Now;

        //        await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new Günlük()
        //        {
        //            Kaynak = "Logger Service", Mesaj = message,
        //            Seviye = OlaySeviye.Ayıklama,
        //            Tarih = şimdi.ToString("dd-MM-yyyy"),
        //            Zaman = şimdi.ToString("hh:mm:ss.fffff")
        //        });

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //        //throw;
        //    }
        //}
        #endregion
    }
}