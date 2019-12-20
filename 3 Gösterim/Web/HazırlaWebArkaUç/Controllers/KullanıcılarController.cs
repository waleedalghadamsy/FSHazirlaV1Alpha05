using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using HazırlaWebArkaUç.Yardımcılar;

namespace HazırlaWebArkaUç.Controllers
{
    public class KullanıcılarController : Controller
    {
        [HttpGet, Route("Kullanıcılar/AdSoyAdKontrolEt/{adSoyad}")]
        public async Task<IActionResult> AdSoyAdKontrolEt(string adSoyad)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {adSoyad}");

                adSoyad = adSoyad.Replace("||", " ");
                return Json(await Yardımcılar.GüvenlikYardımcı.AdSoyadZatenVarMı(adSoyad));
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        [HttpGet, Route("Kullanıcılar/GirişİsimKontrolEt/{girişİsim}")]
        public async Task<IActionResult> GirişİsimKontrolEt(string girişİsim)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {girişİsim}");

                var rslt = Json(await Yardımcılar.GüvenlikYardımcı.GirişİsimZatenKullanıldıMı(girişİsim));

                await HazırlaWebYardımcı.AyıklamaKaydet($"Rslt... {rslt}");

                return rslt;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}