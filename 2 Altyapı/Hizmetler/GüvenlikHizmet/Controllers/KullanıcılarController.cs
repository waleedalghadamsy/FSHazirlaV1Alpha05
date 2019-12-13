using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.Güvenlik;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaVeriAltYapı;
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
        [ActionName("KullanıcılarAl")]
        [HttpGet]
        public async Task<List<Kullanıcı>> Get()
        {
            try
            {
                return await GüvenlikVeriYardımcı.KullanıcılarAl();
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        
        [ActionName("Giriş")]
        [HttpGet("{girişİsim}")]
        public async Task<ActionResult<Kullanıcı>> Giriş(string girişİsim)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                return await GüvenlikVeriYardımcı.Giriş(girişİsim);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        [ActionName("AdSoyadZatenVarMı")]
        [HttpGet("{adSoyad}")]
        public async Task<ActionResult<bool?>> AdSoyadZatenVarMı(string adSoyad)
        {
            try
            {
                return await GüvenlikVeriYardımcı.AdSoyadZatenVarMı(adSoyad);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("GirişİsimZatenKullanıldıMı")]
        [HttpGet("{girişİsim}")]
        public async Task<ActionResult<bool?>> GirişİsimZatenKullanıldıMı(string girişİsim)
        {
            try
            {
                return await GüvenlikVeriYardımcı.GirişİsimZatenKullanıldıMı(girişİsim);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniKullanıcıEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> YeniKullanıcıEkle(Kullanıcı yeniKullanıcı)
        {
            try
            {
                //await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Into...");

                if (!await GüvenlikVeriYardımcı.GirişİsimZatenKullanıldıMı(yeniKullanıcı.Girişİsim))
                {
                    yeniKullanıcı.SistemDurum = VarlıkSistemDurum.Aktif;

                    return await GüvenlikVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı);
                }
                else
                    return new İcraSonuç() { BaşarılıMı = false, Mesaj = "Pardon! Bu isimde başka bir kullanıcı var." };
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("KullanıcıRestoranKaydet")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> KullanıcıRestoranKaydet(KullanıcıRestoran klncRstrn)
        {
            try
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Into...");

                return await GüvenlikVeriYardımcı.KullanıcıRestoranKaydet(klncRstrn);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("KullanıcıDegiştir")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> KullanıcıDegiştir(Kullanıcı kullanıcı)
        {
            try
            {
                await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Into...");

                return await HazırlaVeriAltYapı.GüvenlikVeriYardımcı.KullanıcıDegiştir(kullanıcı);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("KullanıcıKaldır")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> KullanıcıKaldır(List<string> idVeSebep)
        {
            try
            {
                //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                return await GüvenlikVeriYardımcı.KullanıcıKaldır(int.Parse(idVeSebep[0]), idVeSebep[1]);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("ŞifreDegiştir")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> ŞifreDegiştir(List<string> idVeKarmaŞifre)
        {
            try
            {
                return await HazırlaVeriAltYapı.GüvenlikVeriYardımcı.ŞifreDegiştir(int.Parse(idVeKarmaŞifre[0]), idVeKarmaŞifre[1]);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw;
            }
        }
        #endregion
    }
}