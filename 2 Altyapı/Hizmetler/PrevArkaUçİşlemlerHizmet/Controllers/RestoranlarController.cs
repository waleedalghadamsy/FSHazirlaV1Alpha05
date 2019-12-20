using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaVeriAltYapı;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkaUçİşlemlerHizmet.Controllers
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
        public async Task<ActionResult<List<Restoran>>> Get()
        {
            try
            {
                var restoranlar = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranlarAl();

                return restoranlar;
                //if (restoranlar != null && restoranlar.Any())
                //    return Ok(restoranlar);
                //else
                //    return new EmptyResult();
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Restoran>> Get(int id)
        {
            try
            {
                var restoran = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranAl(id);

                return restoran;//Ok(restoran);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("ŞimdikiKullanıcıRestoranlarAl")]
        [HttpGet("{kullanıcıId}")]
        public async Task<ActionResult<List<Restoran>>> ŞimdikiKullanıcıRestoranlarAl(int kullanıcıId)
        {
            try
            {
                return await RestoranlarVeriYardımcı.ŞimdikiKullanıcıRestoranlarAl(kullanıcıId);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniRestoranlarAl")]
        [HttpGet]
        public async Task<ActionResult<List<Restoran>>> YeniRestoranlarAl()
        {
            try
            {
                return await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.YeniRestoranlarAl();
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranFotoğraflarAl")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<VarlıkFotoğraf>>> RestoranFotoğraflarAl(int id)
        {
            try
            {
                var fotolr = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranFotoğraflarAl(id);

                return fotolr;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("HizmetlerDeğiştir")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> HizmetlerDeğiştir(List<string> rstrnIdVeHzmtlr)
        {
            try
            {
                return await RestoranlarVeriYardımcı.HizmetlerDeğiştir(int.Parse(rstrnIdVeHzmtlr[0]),
                                            (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), rstrnIdVeHzmtlr[1]));
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranOnayla")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> RestoranOnayla(int restoranId)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranOnayla(restoranId);

                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranReddet")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> RestoranReddet(List<string> idVeSebep)
        {
            try
            {
                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = "DB Saving new restaurant...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                var sonuç = await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranReddet(int.Parse(idVeSebep[0]), idVeSebep[1]);

                //await HazırlaVeriAltYapı.HazırlaVeriYardımcı.GünlükKaydetme(new HazırlaÇekirdek.Valıklar.VeriGünlüğü.Günlük()
                //{
                //    Seviye = HazırlaÇekirdek.Valıklar.VeriGünlüğü.OlaySeviye.Uyarı,
                //    Kaynak = "RestoranlarController.Post",
                //    Mesaj = sonuç != null ? "Result is there" : "(NULL result)",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                return sonuç;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniRestoranEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Restoran yeniRestoran)
        {
            try
            {
                //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "DB Saving new restaurant...");

                var sonuç = await RestoranlarVeriYardımcı.YeniRestoranEkle(yeniRestoran);

                if (sonuç.BaşarılıMı)
                    HazırlaSistemVeriYardımcı.İşlemKaydet(new Sistemİşlem()
                    {
                        KullanıcıId = yeniRestoran.OluşturuKimsiId,
                        Tip = İşlemTip.YeniRestoranEkledi,
                        ÖğeId = yeniRestoran.Id
                    });

                //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, sonuç != null ? "Result is there" : "(NULL result)");

                return sonuç;

                //if (sonuç.BaşarılıMı)
                //    return Ok(sonuç);//CreatedAtAction(nameof(Post), new { id = yeniRestoran.Id }, yeniRestoran);
                //else
                //    return BadRequest(sonuç);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Restoran restoran)
        {
            try
            {
                var sonuç = await RestoranlarVeriYardımcı.RestoranDeğiştir(restoran);

                if (sonuç.BaşarılıMı)
                    HazırlaSistemVeriYardımcı.İşlemKaydet(new Sistemİşlem()
                    {
                        KullanıcıId = restoran.OluşturuKimsiId,
                        Tip = İşlemTip.RestoranDeğiştirdi,
                        ÖğeId = restoran.Id
                    });

                return sonuç;

                //if (sonuç.BaşarılıMı)
                //    return Ok();
                //else
                //    return BadRequest(sonuç.Mesaj);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        #endregion
    }
}