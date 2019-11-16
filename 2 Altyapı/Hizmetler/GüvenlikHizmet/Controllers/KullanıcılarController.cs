using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
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
        public async Task<ActionResult<Kullanıcı>> Giriş(string girişİsimVeŞifre)
        {
            try
            {
                //await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                var ikisi = girişİsimVeŞifre.Split("<||>");

                return await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.Giriş(ikisi[0].Trim(), ikisi[1].Trim());
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        [ActionName("GirişİsimZatenKullanıldıMı")]
        [HttpGet("{girişİsim}")]
        public async Task<ActionResult<bool?>> GirişİsimZatenKullanıldıMı(string girişİsim)
        {
            try
            {
                return await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.GirişİsimZatenKullanıldıMı(girişİsim);
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
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                if (!await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.GirişİsimZatenKullanıldıMı(yeniKullanıcı.Girişİsim))
                    return await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı);
                else
                    return new İcraSonuç() { BaşarılıMı = false, Mesaj = "Pardo! Bu isimde başka bir kullanıcı var." };
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        [ActionName("KullanıcıDegiştir")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> KullanıcıDegiştir(Kullanıcı kullanıcı)
        {
            try
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                return await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.KullanıcıDegiştir(kullanıcı);
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        [ActionName("ŞifreDegiştir")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> ŞifreDegiştir(Kullanıcı kullanıcı)
        {
            try
            {
                return await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.ŞifreDegiştir(kullanıcı.Id, kullanıcı.Şifre);
            }
            catch (Exception ex)
            {
                await BisiparişVeriAltYapı.BisiparişVeriYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw;
            }
        }
        #endregion
    }
}