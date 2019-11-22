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
    public class MenülerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("YeniMenüKategoriEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> YeniMenüKategoriEkle(Kategori yeniKategori)
        {
            try
            {
                return await BisiparişVeriAltYapı.MenülerVeriYardımcı.YeniMenüKategoriEkle(yeniKategori);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("RestoranMenülerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Menü>>> RestoranMenülerAl(int restoranId)
        {
            try
            {
                return await BisiparişVeriAltYapı.RestoranlarVeriYardımcı.RestoranMenülerAl(restoranId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("MenüAl")]
        [HttpGet("{menüId}")]
        public async Task<ActionResult<Menü>> MenüAl(int menüId)
        {
            try
            {
                await BisiparişVeriAltYapı.MenülerVeriYardımcı.MenüAl(menüId);

                return new Menü();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("YeniMenülerAl")]
        [HttpGet]
        public async Task<ActionResult<List<Menü>>> YeniMenülerAl()
        {
            try
            {
                return await BisiparişVeriAltYapı.MenülerVeriYardımcı.YeniMenülerAl();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("YeniMenüEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Menü yeniMenü)
        {
            try
            {
                return await BisiparişVeriAltYapı.MenülerVeriYardımcı.YeniMenüEkle(yeniMenü);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("MenüOnayla")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> MenüOnayla(int menüId)
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

                var sonuç = await BisiparişVeriAltYapı.MenülerVeriYardımcı.MenüOnayla(menüId);

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

        [ActionName("MenüReddet")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> MenüReddet(Tuple<int, string> idVeSebep)
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

                var sonuç = await BisiparişVeriAltYapı.MenülerVeriYardımcı.MenüReddet(idVeSebep.Item1, idVeSebep.Item2);

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

        [ActionName("MenüDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Menü menü)
        {
            try
            {
                return await BisiparişVeriAltYapı.MenülerVeriYardımcı.MenüDeğiştir(menü);

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