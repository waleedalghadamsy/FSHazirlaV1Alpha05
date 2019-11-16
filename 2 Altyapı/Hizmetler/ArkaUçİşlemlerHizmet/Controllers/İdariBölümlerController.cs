using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkaUçİşlemlerHizmet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class İdariBölümlerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("İller")]
        [HttpGet]
        public async Task<ActionResult<List<İl>>> Getİller()
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Kaynak = "Idari.GetIller",
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Mesaj = "Getting iller...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff")
                //});

                var iller = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İllerAl();

                return new JsonResult(iller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İlçelerOlanİller")]
        [HttpGet]
        public async Task<ActionResult<List<İl>>> İlçelerOlanİllerAl()
        {
            try
            {
                var iller = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İlçelerOlanİllerAl();

                return new JsonResult(iller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<İl>> Getİl(int id)
        {
            try
            {
                var iller = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İlAl(id);

                return new JsonResult(iller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İlçeler")]
        [HttpGet]
        public async Task<ActionResult<List<İlçe>>> Getİlçeler()
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Kaynak = "Idari.GetIller",
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Mesaj = "Getting iller...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff")
                //});

                var ilçeler = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İlçelerAl();

                return new JsonResult(ilçeler);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İlİlçeler")]
        [HttpGet("{ilId}")]
        public async Task<ActionResult<List<İl>>> Getİlİlçeler(int ilId)
        {
            try
            {
                var ilçer = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İlİlçelerAl(ilId);

                return new JsonResult(ilçer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("Semtler")]
        [HttpGet]
        public async Task<ActionResult<List<Semt>>> GetSemtlerler()
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Kaynak = "Idari.GetIller",
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Mesaj = "Getting iller...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff")
                //});

                var smtler = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.SemtlerAl();

                return new JsonResult(smtler);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İlçeSemtler")]
        [HttpGet("{ilçeId}")]
        public async Task<ActionResult<List<Semt>>> GetİlçeSemtler(int ilçeId)
        {
            try
            {
                var semtler = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.İlçeSemtlerAl(ilçeId);

                return new JsonResult(semtler);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("Mahalleler")]
        [HttpGet]
        public async Task<ActionResult<List<Mahalle>>> GetMahallelerler()
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(new BisiparişÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Kaynak = "Idari.GetIller",
                //    Seviye = BisiparişÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Mesaj = "Getting iller...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff")
                //});

                var mhller = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.MahallelerAl();

                return new JsonResult(mhller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("SemtMahalleler")]
        [HttpGet("{semtId}")]
        public async Task<ActionResult<List<Semt>>> GetSemtMahalleler(int semtId)
        {
            try
            {
                var mhler = await BisiparişVeriAltYapı.İdariBölümlerVeriYardımcı.SemtMahallelerAl(semtId);

                return new JsonResult(mhler);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}