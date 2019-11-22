using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Muhasebe;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaliHizmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuponlarController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("Kuponlar")]
        [HttpGet]
        public async Task<ActionResult<List<Kupon>>> Get()
        {
            try
            {
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.KuponlarAl();
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniKuponEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Kupon yeniKupon)
        {
            try
            {
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.YeniKuponEkle(yeniKupon);
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("KuponDeaktifEt")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> KuponDeaktifEt(int kuponId)
        {
            try
            {
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.KuponDeaktifEt(kuponId);
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        #endregion
    }
}