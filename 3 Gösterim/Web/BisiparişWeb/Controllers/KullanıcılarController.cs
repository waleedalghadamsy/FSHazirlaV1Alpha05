using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class KullanıcılarController : Controller
    {
        [HttpGet, Route("Kullanıcılar/AdSoyAdKontrolEt/{adSoyad}")]
        public async Task<IActionResult> AdSoyAdKontrolEt(string adSoyad)
        {
            try
            {
                await BisiparişWebYardımcı.AyıklamaKaydet($"Into... {adSoyad}");

                adSoyad = adSoyad.Replace("||", " ");
                return Json(await Yardımcılar.GüvenlikYardımcı.AdSoyadZatenVarMı(adSoyad));
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        [HttpGet, Route("Kullanıcılar/GirişİsimKontrolEt/{girişİsim}")]
        public async Task<IActionResult> GirişİsimKontrolEt(string girişİsim)
        {
            try
            {
                await BisiparişWebYardımcı.AyıklamaKaydet($"Into... {girişİsim}");

                var rslt = Json(await Yardımcılar.GüvenlikYardımcı.GirişİsimZatenKullanıldıMı(girişİsim));

                await BisiparişWebYardımcı.AyıklamaKaydet($"Rslt... {rslt}");

                return rslt;
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}