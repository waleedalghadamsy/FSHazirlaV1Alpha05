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
        [ActionName("İller")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Restoran>> Get(int id)
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

        [ActionName("ErzakAra")]
        [HttpGet("{aramaMetni}")]
        public async Task<ActionResult<Restoran>> ErzakAra(string aramaMetni)
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

        [ActionName("İller")]
        [HttpPost]
        public async Task<ActionResult> Post(Müşteri yeniMüşteri)
        {
            try
            {
                await Task.Run(() => { });

                return CreatedAtAction(nameof(Post), new { id = yeniMüşteri.Id }, yeniMüşteri);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Müşteri müşteri)
        {
            try
            {
                await Task.Run(() => { });

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}