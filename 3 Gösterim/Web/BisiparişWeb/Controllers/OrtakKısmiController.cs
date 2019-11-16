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

        [HttpGet, Route("OrtakKısmi/İlİlçelerAl/{ilId}")]
        public async Task<IActionResult> İlİlçelerAl(string ilId)
        {
            try
            {
                var ilİlçeler = Modeller.İdariBölümler.İlçelerGörünümModel.İlİlçeler(int.Parse(ilId));

                if (ilİlçeler != null && ilİlçeler.Any())
                {
                    //var selectOptionsSb = new StringBuilder();
                    var selOptions = new List<string>();

                    selOptions.Add("<option value='0'>(İlçe seçiniz)</option>");

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
                var ilçSemteler = Modeller.İdariBölümler.SemtlerGörünümModel.İlçeSemtler(int.Parse(ilçeId));

                //var nSemler = ilçSemteler != null ? $"NSemt: {ilçSemteler.Count}" : "(No semtler)";
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"From ortak -- Semtler: {nSemler}");

                if (ilçSemteler != null && ilçSemteler.Any())
                {
                    var selOptions = new List<string>();

                    selOptions.Add("<option value='0'>(Semt seçiniz)</option>");

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

        [HttpGet, Route("OrtakKısmi/İlçeSemtlerVeMahallelerAl/{ilçeId}")]
        public async Task<IActionResult> İlçeSemtlerVeMahallelerAl(string ilçeId)
        {
            try
            {
                var ilçSemteler = Modeller.İdariBölümler.SemtlerGörünümModel.İlçeSemtler(int.Parse(ilçeId));

                //var nSemler = ilçSemteler != null ? $"NSemt: {ilçSemteler.Count}" : "(No semtler)";
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"From ortak -- Semtler: {nSemler}");

                if (ilçSemteler != null && ilçSemteler.Any())
                {
                    var selOptions = new List<string>();

                    selOptions.Add("<option value='0'>(Semt & Mah. seçiniz)</option>");

                    foreach (var smt in ilçSemteler)
                    {
                        selOptions.Add($"<option value='{smt.Value}'>{smt.Text} (Semt)</option>");

                        foreach (var mh in Modeller.İdariBölümler.MahallelerGörünümModel.SemtMahalleler(int.Parse(smt.Value)))
                            selOptions.Add($"<option value='{mh.Value}'>{mh.Text}</option>");
                    }

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
        public async Task<IActionResult> SemtMahallelerAl(string semtId)
        {
            try
            {
                var semtMhler = Modeller.İdariBölümler.MahallelerGörünümModel.SemtMahalleler(int.Parse(semtId));

                if (semtMhler != null && semtMhler.Any())
                {
                    var selOptions = new List<string>();

                    selOptions.Add("<option value='0'>(Mahalle seçiniz)</option>");

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