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

        [HttpGet, Route("OrtakKısmi/CheckEncoding")]
        public async Task<IActionResult> CheckEncoding()
        {
            var tpEnc = await BisiparişWebYardımcı.GetTypeAndEncoding();
            var strEncSb = new StringBuilder();

            strEncSb.Append($"NEnc: {tpEnc.Item2.Count} -- ");

            foreach (var enc in tpEnc.Item2)
                strEncSb.Append(enc + " | ");

            return Content($"CntTp: {tpEnc.Item1} -- Enc: {strEncSb.ToString()}");
        }

        [HttpGet, Route("OrtakKısmi/İlİlçelerAl/{ilId}")]
        public async Task<IActionResult> İlİlçelerAl(string ilId)
        {
            try
            {
                var ilİlçeler = await BisiparişWebYardımcı.İlİlçelerAl(int.Parse(ilId));

                if (ilİlçeler != null && ilİlçeler.Any())
                {
                    var selectOptionsSb = new StringBuilder();

                    //selectOptionsSb.Append(jsnstr);
                    selectOptionsSb.Append("Found: " + ilİlçeler.Count.ToString());
                    selectOptionsSb.Append("First: " + ilİlçeler[0].Ad);
                    selectOptionsSb.Append("Last: " + ilİlçeler.Last().Ad);
                    selectOptionsSb.Append("<option value='0'>(İlçe seçiniz)</option>");

                    foreach (var ilçe in ilİlçeler)
                        selectOptionsSb.Append($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");

                    return Content(selectOptionsSb.ToString());
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet, Route("OrtakKısmi/NİlİlçelerAl/{ilId}")]
        public async Task<IActionResult> NİlİlçelerAl(string ilId)
        {
            try
            {
                var ilİlçeler = await BisiparişWebYardımcı.İlİlçelerAl2(int.Parse(ilId));

                if (ilİlçeler != null && ilİlçeler.Any())
                {
                    var selectOptionsSb = new StringBuilder();
                    var selOptions = new List<string>();

                    //selectOptionsSb.Append("Found: " + ilİlçeler.Count.ToString());
                    //selectOptionsSb.Append("First: " + ilİlçeler[0].Ad);
                    //selectOptionsSb.Append("Last: " + ilİlçeler.Last().Ad);
                    //selectOptionsSb.Append("<option value='0'>(İlçe seçiniz)</option>");

                    foreach (var ilçe in ilİlçeler)
                        //selectOptionsSb.Append($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");
                        selOptions.Add($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");

                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "İlçe: " + selOptions[0]);

                    return Json(selOptions);// selectOptionsSb.ToString());
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet, Route("OrtakKısmi/CnvİlİlçelerAl/{ilId}")]
        public async Task<IActionResult> CnvİlİlçelerAl(string ilId)
        {
            try
            {
                var ilİlçeler = await BisiparişWebYardımcı.İlİlçelerAl3(int.Parse(ilId));

                if (ilİlçeler != null && ilİlçeler.Any())
                {
                    var selectOptionsSb = new StringBuilder();

                    selectOptionsSb.Append("Found: " + ilİlçeler.Count.ToString());
                    selectOptionsSb.Append("First: " + ilİlçeler[0].Ad);
                    selectOptionsSb.Append("Last: " + ilİlçeler.Last().Ad);
                    selectOptionsSb.Append("<option value='0'>(İlçe seçiniz)</option>");

                    foreach (var ilçe in ilİlçeler)
                        selectOptionsSb.Append($"<option value='{ilçe.Id}'>{ilçe.Ad}</option>");

                    return Content(selectOptionsSb.ToString());
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet, Route("OrtakKısmi/İlçeSemtlerAl/{ilçeId}")]
        public async Task<IActionResult> İlçeSemtlerAl(string ilçeId)
        {
            try
            {
                var ilçSemteler = await BisiparişWebYardımcı.İlçeSemtlerAl(int.Parse(ilçeId));

                var nSemler = ilçSemteler != null ? $"NSemt: {ilçSemteler.Count}" : "(No semtler)";
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"From ortak -- Semtler: {nSemler}");

                if (ilçSemteler != null && ilçSemteler.Any())
                {
                    var selOptions = new List<string>();

                    foreach (var smt in ilçSemteler)
                        selOptions.Add($"<option value='{smt.Id}'>{smt.Ad}</option>");

                    return Json(selOptions);
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet, Route("OrtakKısmi/SemtMahallelerAl/{semtId}")]
        public async Task<IActionResult> SemtMahallelerAl(string semtId)
        {
            try
            {
                var semtMhler = await BisiparişWebYardımcı.SemtMahallelerAl(int.Parse(semtId));

                if (semtMhler != null && semtMhler.Any())
                {
                    var selOptions = new List<string>();

                    foreach (var mh in semtMhler)
                        selOptions.Add($"<option value='{mh.Id}'>{mh.Ad}</option>");

                    return Json(selOptions);
                }
                else
                    return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}