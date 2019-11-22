using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Muhasebe;
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.RestoranYeniSiparişlerAl(restoranId);
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.RestoranBeklemeSiparişlerAl(restoranId);
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişDurumAl(siparişId);
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.YeniSiparişEkle(yeniSipariş);

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
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişOnayla(siparişId);

                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
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
        public async Task<ActionResult<İcraSonuç>> SiparişReddet(Tuple<int, string> idVeSebep)
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

                var sonuç = await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişReddet(idVeSebep.Item1, idVeSebep.Item2);

                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
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
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await BisiparişVeriAltYapı.MaliVeriYardımcı.Siparişİptal(siparişId);

                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişDeğiştir(sipariş);

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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişHazırla(siparişId);
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişYapıldı(siparişId);
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
                return await BisiparişVeriAltYapı.MaliVeriYardımcı.SiparişTeslimEdildi(siparişId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}