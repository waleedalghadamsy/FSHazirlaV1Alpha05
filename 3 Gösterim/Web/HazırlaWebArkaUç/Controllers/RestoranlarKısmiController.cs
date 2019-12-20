using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaWebArkaUç.Yardımcılar;

namespace HazırlaWebArkaUç.Controllers
{
    public class RestoranlarKısmiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("RestoranlarKısmi/RestoranHizmetSeçildi/{dizHizmetDeğer}/{seçildiMi}")]
        public IActionResult RestoranHizmetSeçildi(string dizHizmetDeğer, bool seçildiMi)
        {
            try
            {
                var hizmet = (RestoranHizmetler)long.Parse(dizHizmetDeğer);

                HazırlaWebYardımcı.ŞuAnkiKullanıcıYeniRestoranHizmetler |= seçildiMi ? hizmet : ~hizmet;

                return Ok();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await HazırlaWebYardımcı.HataKaydet(ex));
                throw ex;
            }
        }

        [HttpGet, Route("RestoranlarKısmi/RestoranMenüKategorilerAl/{restoranId}")]
        public async Task<IActionResult> RestoranMenüKategorilerAl(string restoranId)
        {
            List<Kategori> ktgrlr = null;

            try
            {
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Into {restoranId}");

                //var jsnKtgrlr = HazırlaWebYardımcı.Session.Keys.Contains($"Rstrn_{restoranId}_MnüKtgrlr")
                //                ? HazırlaWebYardımcı.Session.GetString($"Rstrn_{restoranId}_MnüKtgrlr")
                //                : null;

                var jsnKtgrlr = HazırlaWebYardımcı.MemCache.Get<string>($"Rstrn_{restoranId}_MnüKtgrlr");

                if (!string.IsNullOrWhiteSpace(jsnKtgrlr))
                    //ktgrlr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kategori>>(jsnKtgrlr);
                    ktgrlr = System.Text.Json.JsonSerializer.Deserialize<List<Kategori>>(jsnKtgrlr, 
                        new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                else
                    ktgrlr = await MenülerYardımcı.RestoranMenüKategorilerAl(int.Parse(restoranId));

                if (ktgrlr != null && ktgrlr.Any())
                {
                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Found {ktgrlr.Count} categories");

                    var selOptions = new List<string>();

                    selOptions.Add("<option value='0'>(Kategori seçiniz)</option>");

                    foreach (var kat in ktgrlr)
                        selOptions.Add($"<option value='{kat.Id}'>{kat.Ad}</option>");

                    //await HazırlaWebYardımcı.AyıklamaKaydet($"{selOptions}");

                    return Json(selOptions);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        [HttpGet, Route("RestoranlarKısmi/MenüKategoriAltKategorilerAl/{rstrnId}/{katId}")]
        public async Task<IActionResult> MenüKategoriAltKategorilerAl(string rstrnId, string katId)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into {rstrnId} | {katId}");

                //var jsnKtgrlr = HazırlaWebYardımcı.Session.Keys.Contains($"Rstrn_{rstrnId}_MnüKtgrlr")
                //                ? HazırlaWebYardımcı.Session.GetString($"Rstrn_{rstrnId}_MnüKtgrlr")
                //                : null;

                var jsnKtgrlr = HazırlaWebYardımcı.MemCache.Get<string>($"Rstrn_{rstrnId}_MnüKtgrlr");

                //var ktg = !string.IsNullOrWhiteSpace(jsnKtgrlr) ? jsnKtgrlr : "(null)";
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Rstrn cat {ktg}");

                if (!string.IsNullOrWhiteSpace(jsnKtgrlr))
                {
                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Rstrn cat {jsnKtgrlr}");

                    //var ktgrlr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kategori>>(jsnKtgrlr);
                    var ktgrlr = System.Text.Json.JsonSerializer.Deserialize<List<Kategori>>(jsnKtgrlr,
                                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    var kat = ktgrlr.First(k => k.Id == int.Parse(katId));
                    //var naltkat = kat.AltKategoriler != null ? kat.AltKategoriler.Count.ToString() : "(null)";

                    //await HazırlaWebYardımcı.AyıklamaKaydet($"Cat {kat.Ad} -- {naltkat}");

                    if (kat.AltKategoriler != null && kat.AltKategoriler.Any())
                    {
                        //await HazırlaWebYardımcı.AyıklamaKaydet($"Enumerating...");

                        var selOptions = new List<string>();

                        selOptions.Add("<option value='0'>(Alt kategori seçiniz)</option>");

                        foreach (var altkat in kat.AltKategoriler)
                            selOptions.Add($"<option value='{altkat.Id}'>{altkat.Ad}</option>");

                        return Json(selOptions);
                    }
                    else
                        return new EmptyResult();
                }
                else
                    return new EmptyResult();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        [HttpGet, Route("RestoranlarKısmi/RestoranMasaHazırlatVeGelAlHizmetlerAl/{rstrnId}")]
        public async Task<IActionResult> RestoranMasaHazırlatVeGelAlHizmetlerAl(string rstrnId)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into {rstrnId}");

                var jsnRstrnlr = HazırlaWebYardımcı.MemCache.Get<string>($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr");

                //var jsnRstrnlr = HazırlaWebYardımcı.Session.Keys.Contains($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr")
                //                ? HazırlaWebYardımcı.Session.GetString($"Klnc_{GüvenlikYardımcı.ŞimdikiKullanıcıId}_Rstrnlr")
                //                : null;

                if (!string.IsNullOrWhiteSpace(jsnRstrnlr))
                {
                    //var rstrnlr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsnRstrnlr);
                    var rstrnlr = System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsnRstrnlr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    var rstrn = rstrnlr.First(r => r.Id == int.Parse(rstrnId));
                    var masaHzrlt = (rstrn.Hizmetler & RestoranHizmetler.MasaHazırlat) == RestoranHizmetler.MasaHazırlat;
                    var gelAl = (rstrn.Hizmetler & RestoranHizmetler.GelAl) == RestoranHizmetler.GelAl;

                    return Json(new List<string>() { masaHzrlt.ToString(), gelAl.ToString() });
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}