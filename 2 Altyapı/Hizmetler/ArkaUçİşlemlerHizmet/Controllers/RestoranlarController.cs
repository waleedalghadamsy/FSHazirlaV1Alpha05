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
    public class RestoranlarController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("RestoranlarAl")]
        [HttpGet]
        public async Task<ActionResult<List<Restoran>>> Get()
        {
            try
            {
                var restoranlar = await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.RestoranlarAl();

                return restoranlar;
                //if (restoranlar != null && restoranlar.Any())
                //    return Ok(restoranlar);
                //else
                //    return new EmptyResult();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("RestoranAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Restoran>> Get(int id)
        {
            try
            {
                var restoran = await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.RestoranAl(id);

                return restoran;//Ok(restoran);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[ActionName("RestoranİletişimAl")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<İşyeriİletişim>> RestoranİletişimAl(int id)
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

        [ActionName("RestoranFotoğraflarAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<VarlıkFotoğraf>>> RestoranFotoğraflarAl(int id)
        {
            try
            {
                var fotolr = await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.RestoranFotoğraflarAl(id);

                return fotolr;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("YeniRestoranEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Restoran yeniRestoran)
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.YeniRestoranEkle(yeniRestoran);

                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;

                //if (sonuç.BaşarılıMı)
                //    return Ok(sonuç);//CreatedAtAction(nameof(Post), new { id = yeniRestoran.Id }, yeniRestoran);
                //else
                //    return BadRequest(sonuç);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("RestoranDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Restoran restoran)
        {
            try
            {
                var sonuç = await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.RestoranDeğiştir(restoran);

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