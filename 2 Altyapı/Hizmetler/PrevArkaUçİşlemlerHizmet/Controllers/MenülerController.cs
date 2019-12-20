﻿using System;
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
                return await HazırlaVeriAltYapı.MenülerVeriYardımcı.YeniMenüKategoriEkle(yeniKategori);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniMenüKategorilerEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> YeniMenüKategorilerEkle(List<Kategori> yeniKategoriler)
        {
            İcraSonuç finalSonuç;

            try
            {
                finalSonuç = new İcraSonuç() { BaşarılıMı = true };

                foreach (var kat in yeniKategoriler)
                {
                    var sonuç = await HazırlaVeriAltYapı.MenülerVeriYardımcı.YeniMenüKategoriEkle(kat);

                    if (sonuç.BaşarılıMı && kat.AltKategoriler != null && kat.AltKategoriler.Any())
                        foreach(var altkat in kat.AltKategoriler)
                        {
                            altkat.TemelKategoriId = sonuç.YeniEklediId;
                            await HazırlaVeriAltYapı.MenülerVeriYardımcı.YeniMenüKategoriEkle(altkat);
                        }

                    finalSonuç.BaşarılıMı &= sonuç.BaşarılıMı;
                }

                return finalSonuç;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranMenüKategorilerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Kategori>>> RestoranMenüKategorilerAl(int restoranId)
        {
            List<Kategori> kategoriler = null;

            try
            {
                var ktgrlr = await HazırlaVeriAltYapı.MenülerVeriYardımcı.RestoranMenüKategorilerAl(restoranId);

                if (ktgrlr != null && ktgrlr.Any())
                {
                    kategoriler = new List<Kategori>();

                    foreach(var kat in ktgrlr.Where(k => !k.TemelKategoriId.HasValue))
                        kategoriler.Add(kat);

                    foreach (var kat in ktgrlr.Where(k => k.TemelKategoriId.HasValue))
                    {
                        var tmlKat = kategoriler.FirstOrDefault(k => k.Id == kat.TemelKategoriId.Value);

                        if (tmlKat != null)
                        {
                            if (tmlKat.AltKategoriler == null)
                                tmlKat.AltKategoriler = new List<Kategori>();

                            tmlKat.AltKategoriler.Add(kat);
                        }
                    }
                }

                return kategoriler;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("RestoranMenülerAl")]
        [HttpGet("{restoranId}")]
        public async Task<ActionResult<List<Menü>>> RestoranMenülerAl(int restoranId)
        {
            try
            {
                return await HazırlaVeriAltYapı.RestoranlarVeriYardımcı.RestoranMenülerAl(restoranId);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("MenüAl")]
        [HttpGet("{menüId}")]
        public async Task<ActionResult<Menü>> MenüAl(int menüId)
        {
            try
            {
                await HazırlaVeriAltYapı.MenülerVeriYardımcı.MenüAl(menüId);

                return new Menü();
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniMenülerAl")]
        [HttpGet]
        public async Task<ActionResult<List<Menü>>> YeniMenülerAl()
        {
            try
            {
                return await HazırlaVeriAltYapı.MenülerVeriYardımcı.YeniMenülerAl();
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("YeniMenüEkle")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> Post(Menü yeniMenü)
        {
            try
            {
                return await HazırlaVeriAltYapı.MenülerVeriYardımcı.YeniMenüEkle(yeniMenü);

                //return CreatedAtAction(nameof(Post), new { id = yeniMenü.Id }, yeniMenü);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        [ActionName("MenüOnayla")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> MenüOnayla(int menüId)
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

                var sonuç = await MenülerVeriYardımcı.MenüOnayla(menüId);

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

        [ActionName("MenüReddet")]
        [HttpPost]
        public async Task<ActionResult<İcraSonuç>> MenüReddet(List<string> idVeSebep)
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

                var sonuç = await MenülerVeriYardımcı.MenüReddet(int.Parse(idVeSebep[0]), idVeSebep[1]);

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

        [ActionName("MenüDeğiştir")]
        [HttpPut]
        public async Task<ActionResult<İcraSonuç>> Put(Menü menü)
        {
            try
            {
                return await MenülerVeriYardımcı.MenüDeğiştir(menü);

                //return Ok();
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