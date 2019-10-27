using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkaUçİşlemlerHizmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ÜlkelerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [HttpGet]
        public async Task<ActionResult<List<Ülke>>> Get()
        {
            try
            {
                var ülkeler = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.ÜlkelerAl();

                return ülkeler;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}