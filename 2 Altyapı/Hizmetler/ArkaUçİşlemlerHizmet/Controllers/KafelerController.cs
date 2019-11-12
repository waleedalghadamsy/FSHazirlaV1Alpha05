using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkaUçİşlemlerHizmet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KafelerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        //[ActionName("KafelerAl")]
        //[HttpGet]
        //public async Task<ActionResult<List<Kafe>>> Get()
        //{
        //    try
        //    {
        //        var kafeler = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.KafelerAl();

        //        return kafeler;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[ActionName("KafeAl")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Kafe>> Get(int id)
        //{
        //    try
        //    {
        //        var kafe = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.KafeAl(id);

        //        return kafe;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[ActionName("KafeFotoğraflarAl")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<VarlıkFotoğraf>>> KafeFotoğraflarAl(int id)
        //{
        //    try
        //    {
        //        return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.KafeFotoğraflarAl(id);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[ActionName("KafeİletişimAl")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<İşyeriİletişim>> KafeİletişimAl(int id)
        //{
        //    try
        //    {
        //        return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İşyeriİletişimAl(id);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [ActionName("YeniKafeEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Kafe yeniKafe)
        {
            try
            {
                var sonuç = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.YeniKafeEkle(yeniKafe);

                return sonuç;
                //if (sonuç.BaşarılıMı)
                //    return CreatedAtAction(nameof(Post), new { id = yeniKafe.Id }, yeniKafe);
                //else
                //    return BadRequest(sonuç.Mesaj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("KafeDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Kafe kafe)
        {
            try
            {
                var sonuç = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.KafeDeğiştir(kafe);

                return sonuç;
                //if (sonuç.BaşarılıMı)
                //    return Ok();
                //else
                //    return BadRequest(sonuç.Mesaj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}