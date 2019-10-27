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
                var iller = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İllerAl();

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
                var iller = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İlAl(id);

                return new JsonResult(iller);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("İlİlçeler")]
        [HttpGet("{ilPlaka}")]
        public async Task<ActionResult<List<İl>>> Getİlİlçeler(int ilPlaka)
        {
            try
            {
                var ilçer = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İlİlçelerAl(ilPlaka);

                return new JsonResult(ilçer);
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
                var semtler = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.İlçeSemtlerAl(ilçeId);

                return new JsonResult(semtler);
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
                var mhler = await BisiparişVeriAltYapı.BisiparişVeriYardımcı.SemtMahallelerAl(semtId);

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