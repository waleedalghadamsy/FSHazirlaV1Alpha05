using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÖnUçİşlemlerHizmet.Controllers
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
        public async Task<ActionResult<List<Restoran>>> RestoranlarAl()
        {
            try
            {
                return await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranlarAl(true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("RestoranAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Restoran>> RestoranAl(int id)
        {
            try
            {
                //return await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.DetaylıRestoranAl(id);
                return await Yardımcılar.ÖnUçHizmetYardımcı.RestoranAl(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[ActionName("ErzakAra")]
        //[HttpGet("{aramaDizisi}")]
        //public async Task<ActionResult<List<Restoran>>> ErzakAra(string aramaDizisi)
        //{
        //    try
        //    {
        //        //var rstrnlr = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.ErzakAra(aramaDizisi);
        //        var rstrnlr = await Yardımcılar.ÖnUçHizmetYardımcı.ErzakAra(aramaDizisi);

        //        if (rstrnlr != null && rstrnlr.Any())
        //            return rstrnlr.ToList();
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        await HazırlaVeriAltYapı.HazırlaVeriYardımcı.HayaKaydet(ex);
        //        throw ex;
        //    }
        //}

        [ActionName("ErzakAra")]
        [HttpGet("{aramaDizisi}")]
        public async Task<ActionResult<List<RestoranAramaSonuç>>> ErzakAra(string aramaDizisi)
        {
            try
            {
                //var rstrnlr = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.ErzakAra(aramaDizisi);
                var rstrnlr = await Yardımcılar.ÖnUçHizmetYardımcı.ErzakAra(aramaDizisi);

                if (rstrnlr != null && rstrnlr.Any())
                    return rstrnlr.Select(r => new RestoranAramaSonuç() 
                                { RestoranId = r.Id, Restoranİsim = r.İsim, RestoranResim = r.Fotoğraflar[0] }).ToList();
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaVeriAltYapı.HazırlaVeriYardımcı.HayaKaydet(ex);
                throw ex;
            }
        }

        [ActionName("BölgedeRestoranlarAl")]
        [HttpGet("{ilId}/{ilçeId}/{semtId}")]
        public async Task<ActionResult<List<RestoranAramaSonuç>>> BölgedeRestoranlarAl(int ilId, int ilçeId, int semtId)
        {
            try
            {
                //var rstrnlr = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.ErzakAra(aramaDizisi);
                var rstrnlr = Yardımcılar.ÖnUçHizmetYardımcı.BölgedeRestoranlarAl(ilId, ilçeId, semtId);

                if (rstrnlr != null && rstrnlr.Any())
                    return rstrnlr.Select(r => new RestoranAramaSonuç()
                    { RestoranId = r.Id, Restoranİsim = r.İsim, RestoranResim = r.Fotoğraflar[0] }).ToList();
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaVeriAltYapı.HazırlaVeriYardımcı.HayaKaydet(ex);
                throw ex;
            }
        }

        [ActionName("BölgedeErzakAra")]
        [HttpGet("{aramaDizisi}/{ilId}/{ilçeId}/{semtId}")]
        public async Task<ActionResult<List<RestoranAramaSonuç>>> BölgedeErzakAra(string aramaDizisi, int ilId, int ilçeId, int semtId)
        {
            try
            {
                //var rstrnlr = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.ErzakAra(aramaDizisi);
                var rstrnlr = await Yardımcılar.ÖnUçHizmetYardımcı.BölgedeErzakAra(aramaDizisi, ilId, ilçeId, semtId);

                if (rstrnlr != null && rstrnlr.Any())
                    return rstrnlr.Select(r => new RestoranAramaSonuç()
                    { RestoranId = r.Id, Restoranİsim = r.İsim, RestoranResim = r.Fotoğraflar[0] }).ToList();
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaVeriAltYapı.HazırlaVeriYardımcı.HayaKaydet(ex);
                throw ex;
            }
        }

        [ActionName("ErzakAraÖncekiSayfa")]
        [HttpGet("{aramaMetni}")]
        public async Task<ActionResult<Restoran>> ErzakAraÖncekiSayfa(string aramaMetni)
        {
            Restoran restoran = null;

            try
            {
                await Task.Run(() => { });

                return Ok(restoran);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("ErzakAraSonrakiSayfa")]
        [HttpGet("{aramaMetni}")]
        public async Task<ActionResult<Restoran>> ErzakAraSonrakiSayfa(string aramaMetni)
        {
            Restoran restoran = null;

            try
            {
                await Task.Run(() => { });

                return Ok(restoran);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}