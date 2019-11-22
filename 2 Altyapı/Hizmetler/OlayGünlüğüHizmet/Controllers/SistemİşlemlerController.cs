using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OlayGünlüğüHizmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemİşlemlerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [HttpPost]
        public async Task<ActionResult> Post(Sistemİşlem işlem)
        {
            string tracer = "";

            try
            {
                //tracer = "[1] | " + jsonGünlük;
                //var günlük = Newtonsoft.Json.JsonConvert.DeserializeObject<Günlük>(jsonGünlük);
                //tracer = "[2]";
                //tracer = "[3]";
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.SistemİşlemKaydet(işlem);
                //tracer = "[4]";

                return Ok();// tracer);// + " | " + dbResult);
            }
            catch (Exception ex)
            {
                return Content(tracer + " | CATCH-ERROR: " + ex.Message);
                //throw;
            }
        }
        #endregion
    }
}