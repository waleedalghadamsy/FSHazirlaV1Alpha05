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
    public class İletişimController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        //[ActionName("İşyeriİletişimAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<İşyeriİletişim>> Get(int id)
        {
            try
            {
                return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İşyeriİletişimAl(id);

                //return new JsonResult(iller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}