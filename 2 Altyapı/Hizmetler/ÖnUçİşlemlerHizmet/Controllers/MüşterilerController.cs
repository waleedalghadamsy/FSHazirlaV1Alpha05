using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÖnUçİşlemlerHizmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MüşterilerController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [HttpGet("{id}")]
        public async Task<ActionResult<Müşteri>> Get(int id)
        {
            Müşteri müşteri = null;

            try
            {
                await Task.Run(() => { });

                return Ok(müşteri);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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