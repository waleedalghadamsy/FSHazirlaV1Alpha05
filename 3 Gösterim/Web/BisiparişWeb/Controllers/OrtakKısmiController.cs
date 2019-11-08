using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    //[Route("[controller]/[action]")]
    public class OrtakKısmiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet, Route("OrtakKısmi/CheckEncoding")]
        //public async Task<IActionResult> CheckEncoding()
        //{
        //    var tpEnc = await BisiparişWebYardımcı.GetTypeAndEncoding();
        //    var strEncSb = new StringBuilder();

        //    strEncSb.Append($"NEnc: {tpEnc.Item2.Count} -- ");

        //    foreach (var enc in tpEnc.Item2)
        //        strEncSb.Append(enc + " | ");

        //    return Content($"CntTp: {tpEnc.Item1} -- Enc: {strEncSb.ToString()}");
        //}

        //[HttpGet, Route("OrtakKısmi/NİlİlçelerAl/{ilId}")]
        //public async Task<IActionResult> NİlİlçelerAl(string ilId)
        //{
        //    try
        //    {
        //        var ilİlçeler = await BisiparişWebYardımcı.İlİlçelerAl2(int.Parse(ilId));

        //        if (ilİlçeler != null && ilİlçeler.Any())
        //        {
        //            var selectOptionsSb = new StringBuilder();
        //            var selOptions = new List<string>();

        //            //selectOptionsSb.Append("Found: " + ilİlçeler.Count.ToString());
        //            //selectOptionsSb.Append("First: " + ilİlçeler[0].Ad);
        //            //selectOptionsSb.Append("Last: " + ilİlçeler.Last().Ad);
        //            //selectOptionsSb.Append("<option value='0'>(İlçe seçiniz)</option>");

        //            foreach (var ilçe in ilİlçeler)
        //                //selectOptionsSb.Append($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");
        //                selOptions.Add($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");

        //            //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "İlçe: " + selOptions[0]);

        //            return Json(selOptions);// selectOptionsSb.ToString());
        //        }
        //        else
        //            return Content("");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}

        //[HttpGet, Route("OrtakKısmi/İlçeSemtlerAl/{ilçeId}")]
        //public async Task<IActionResult> İlçeSemtlerAl(string ilçeId)
        //{
        //    try
        //    {
        //        var ilçSemteler = await BisiparişWebYardımcı.İlçeSemtlerAl(int.Parse(ilçeId));

        //        var nSemler = ilçSemteler != null ? $"NSemt: {ilçSemteler.Count}" : "(No semtler)";
        //        //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"From ortak -- Semtler: {nSemler}");

        //        if (ilçSemteler != null && ilçSemteler.Any())
        //        {
        //            var selOptions = new List<string>();

        //            foreach (var smt in ilçSemteler)
        //                selOptions.Add($"<option value='{smt.Id}'>{smt.Ad}</option>");

        //            return Json(selOptions);
        //        }
        //        else
        //            return Content("");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}

        //[HttpGet, Route("OrtakKısmi/SemtMahallelerAl/{semtId}")]
        //public async Task<IActionResult> SemtMahallelerAl(string semtId)
        //{
        //    try
        //    {
        //        var semtMhler = await BisiparişWebYardımcı.SemtMahallelerAl(int.Parse(semtId));

        //        if (semtMhler != null && semtMhler.Any())
        //        {
        //            var selOptions = new List<string>();

        //            foreach (var mh in semtMhler)
        //                selOptions.Add($"<option value='{mh.Id}'>{mh.Ad}</option>");

        //            return Json(selOptions);
        //        }
        //        else
        //            return Content("");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}

        [HttpGet, Route("OrtakKısmi/NİlİlçelerAl/{ilId}")]
        public async Task<IActionResult> NİlİlçelerAl(string ilId)
        {
            try
            {
                //var nİlId = int.Parse(ilId);
                //var iller = BisiparişWebYardımcı.Tümİller;
                //var ilİlçeler = iller.First(il => il.Id == nİlId).İlçeler;

                var ilİlçeler = Modeller.İdariBölümler.İlçelerGörünümModel.İlİlçeler(int.Parse(ilId));

                if (ilİlçeler != null && ilİlçeler.Any())
                {
                    //var selectOptionsSb = new StringBuilder();
                    var selOptions = new List<string>();

                    foreach (var ilçe in ilİlçeler)
                        selOptions.Add($"<option value='{ilçe.Value}'>{ilçe.Text}</option>");

                    return Json(selOptions);
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                return Content("");
            }
        }

        [HttpGet, Route("OrtakKısmi/İlçeSemtlerAl/{ilçeId}")]
        public async Task<IActionResult> İlçeSemtlerAl(string ilçeId)
        {
            try
            {
                //var nİlId = int.Parse(ilId); var nİlçeId = int.Parse(ilçeId);
                //var iller = BisiparişWebYardımcı.Tümİller;
                //var birİlçe = iller.First(il => il.Id == nİlId).İlçeler.First(ilçe => ilçe.Id == nİlçeId);
                //var ilçSemteler = birİlçe.Semtler;

                var ilçSemteler = Modeller.İdariBölümler.SemtlerGörünümModel.İlçeSemtler(int.Parse(ilçeId));

                //var nSemler = ilçSemteler != null ? $"NSemt: {ilçSemteler.Count}" : "(No semtler)";
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"From ortak -- Semtler: {nSemler}");

                if (ilçSemteler != null && ilçSemteler.Any())
                {
                    var selOptions = new List<string>();

                    foreach (var smt in ilçSemteler)
                        selOptions.Add($"<option value='{smt.Value}'>{smt.Text}</option>");

                    return Json(selOptions);
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                return Content("");
            }
        }

        [HttpGet, Route("OrtakKısmi/SemtMahallelerAl/{semtId}")]
        public async Task<IActionResult> SemtMahallelerAl(string ilId, string ilçeId, string semtId)
        {
            try
            {
                //var nİlId = int.Parse(ilId); var nİlçeId = int.Parse(ilçeId); var nSemtId = int.Parse(semtId);
                //var iller = BisiparişWebYardımcı.Tümİller;
                //var birİlçe = iller.First(il => il.Id == nİlId).İlçeler.First(ilçe => ilçe.Id == nİlçeId);
                //var birSemt = birİlçe.Semtler.First(st => st.Id == nSemtId);
                //var semtMhler = birSemt.Mahalleler;

                var semtMhler = Modeller.İdariBölümler.MahallelerGörünümModel.SemtMahalleler(int.Parse(semtId));

                if (semtMhler != null && semtMhler.Any())
                {
                    var selOptions = new List<string>();

                    foreach (var mh in semtMhler)
                        selOptions.Add($"<option value='{mh.Value}'>{mh.Text}</option>");

                    return Json(selOptions);
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                return Content("");
            }
        }
    }
}