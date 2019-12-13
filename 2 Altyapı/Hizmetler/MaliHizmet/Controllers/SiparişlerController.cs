using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.Muhasebe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaliHizmet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SiparişlerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("RestoranYeniSiparişlerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Sipariş>>> RestoranYeniSiparişlerAl(int restoranId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.RestoranYeniSiparişlerAl(restoranId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("RestoranBeklemeSiparişlerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Sipariş>>> RestoranBeklemeSiparişlerAl(int restoranId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.RestoranBeklemeSiparişlerAl(restoranId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişDurumAl")]
        [HttpGet("{siparişId}")]
        public static async Task<ActionResult<SiparişDurum>> SiparişDurumAl(int siparişId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişDurumAl(siparişId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("YeniSiparişEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Sipariş yeniSipariş)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.YeniSiparişEkle(yeniSipariş);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişOnayla")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> SiparişOnayla(int siparişId)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişOnayla(siparişId);

                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişReddet")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> SiparişReddet(List<string> idVeSebep)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişReddet(int.Parse(idVeSebep[0]), idVeSebep[1]);

                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("Siparişİptal")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Siparişİptal(int siparişId)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await HazırlaVeriAltYapı.MaliVeriYardımcı.Siparişİptal(siparişId);

                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Sipariş sipariş)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişDeğiştir(sipariş);

                //return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişHazırla")]
        [HttpPost]
        public static async Task<ActionResult<İcraSonuç>> SiparişHazırla(int siparişId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişHazırla(siparişId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişYapıldı")]
        [HttpPost]
        public static async Task<ActionResult<İcraSonuç>> SiparişYapıldı(int siparişId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişYapıldı(siparişId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SiparişTeslimEdildi")]
        [HttpPost]
        public static async Task<ActionResult<İcraSonuç>> SiparişTeslimEdildi(int siparişId)
        {
            try
            {
                return await HazırlaVeriAltYapı.MaliVeriYardımcı.SiparişTeslimEdildi(siparişId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}