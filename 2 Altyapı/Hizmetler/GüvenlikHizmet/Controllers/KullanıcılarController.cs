using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GüvenlikHizmet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullanıcılarController : ControllerBase
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        [ActionName("Giriş")]
        [HttpGet("{girişİsimVeŞifre}")]
        public async Task<ActionResult<Kullanıcı>> Giriş((string, string) girişİsimVeŞifre)
        {
            try
            {
                return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.Giriş(girişİsimVeŞifre.Item1, girişİsimVeŞifre.Item2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("GirişİsimZatenKullanıldıMı")]
        [HttpGet("{girişİsim}")]
        public async Task<ActionResult<bool?>> GirişİsimZatenKullanıldıMı(string girişİsim)
        {
            try
            {
                return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GirişİsimZatenKullanıldıMı(girişİsim);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ActionName("YeniKullanıcıEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> YeniKullanıcıEkle(Kullanıcı yeniKullanıcı)
        {
            try
            {
                if (!await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GirişİsimZatenKullanıldıMı(yeniKullanıcı.Girişİsim))
                    return await BisiparişVeriAltYapı.BisiparişVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı);
                else
                    return new İcraSonuç() { BaşarılıMı = false, Mesaj = "Pardo! Bu isimde başka bir kullanıcı var." };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}