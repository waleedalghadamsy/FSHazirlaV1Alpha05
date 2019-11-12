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
    [Route("api/[controller]")]
    [ApiController]
    public class MenülerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("RestoranMenülerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Menü>>> GetRestoranMenüler(int restoranId)
        {
            try
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.RestoranMenülerAl(restoranId);

                return new List<Menü>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[ActionName("KafeMenülerAl")]
        //[HttpGet("{kafeId}")]
        //public async Task<ActionResult<List<Menü>>> GetKafeMenüler(int kafeId)
        //{
        //    try
        //    {
        //        await BisiparişVeriAltYapı.BisiparişVeriYardımcı.KafeMenülerAl(kafeId);

        //        return new List<Menü>();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [ActionName("MenüAl")]
        [HttpGet("{menüId}")]
        public async Task<ActionResult<Menü>> GetMenü(int menüId)
        {
            try
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.MenüAl(menüId);

                return new Menü();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Menü yeniMenü)
        {
            try
            {
                return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.YeniMenüEkle(yeniMenü);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Menü menü)
        {
            try
            {
                return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.MenüDeğiştir(menü);

                //return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}