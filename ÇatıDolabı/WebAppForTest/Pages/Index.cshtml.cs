using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace WebAppForTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string RootDirectory { get; set; }
        [BindProperty]
        public List<SelectListItem> OpItems { get; set; }
        public void OnGet()
        {
            //var a = Url.Action("AnotherOperation", "TestLab");
            //var v = Url.RouteUrl("TestLab/AnotherOperation");
            RootDirectory = Request.Host.Value;

            OpItems = new List<SelectListItem>()
            {
                new SelectListItem("Op 1", "1"),
                new SelectListItem("Op 2", "2"),
                new SelectListItem("Op 3", "3"),
            };

            //var chkBxDropDn = CheckBoxDropDown("abc", OpItems);

            //await GünlükKaydetme(new Günlük()
            //{
            //    Seviye = OlaySeviye.Ayıklama,
            //    Mesaj = "Another test from here",
            //    Kaynak = "", Tarih = "0", Zaman = "0"
            //});
        }

        private static string GünlükHizmetUrl => "http://localhost:11011/api";
        private static string GünlüklerUrl => $"{GünlükHizmetUrl}/Günlükçü";

        //public static async Task GünlükKaydetme(Günlük günlük,
        //    [CallerFilePath] string dosyaYolu = "", [CallerMemberName] string üyeAd = "")
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            if (!string.IsNullOrWhiteSpace(dosyaYolu) || !string.IsNullOrWhiteSpace(üyeAd))
        //                günlük.Kaynak = $"{dosyaYolu} | {üyeAd}";

        //            var jsonLog = JsonİçerikOluştur(günlük);
        //            var result  = await istemci.PostAsync(GünlüklerUrl, jsonLog);
        //            //var result = await istemci.PostAsync(GünlüklerUrl + "/OnlyForTest", JsonİçerikOluştur("First trial"));

        //            var msg = await result.Content.ReadAsStringAsync();
        //            //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public static async Task GünlükKaydetme(Günlük günlük)
        //{
        //    try
        //    {
        //        var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

        //        günlük.Kaynak = $"{methodContainer.FullName}.{method.Name}";

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var result = await istemci.PostAsync(GünlüklerUrl, JsonİçerikOluştur(günlük));
        //            //var result = await istemci.PostAsync(GünlüklerUrl + "/OnlyForTest", JsonİçerikOluştur("First trial"));

        //            var msg = await result.Content.ReadAsStringAsync();
        //            //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //private static System.Net.Http.StringContent JsonİçerikOluştur<T>(T nesne)
        //{
        //    try
        //    {
        //        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(nesne);//System.Text.Json.JsonSerializer.Serialize<T>(nesne);
        //        var içerik = new System.Net.Http.StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");
        //        //içerik.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        return içerik;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static string CheckBoxDropDown(string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
        {
            try
            {
                var attrValues = GetHtmlAttributes(htmlAttributes);
                var idAttr = (htmlAttributes != null && attrValues != null
                            && attrValues.Keys.Any(k => string.Compare(k, "id", true) == 0)) ?
                            attrValues["id"] : null;
                //var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
                //string propertyName = (idAttr != null) ? idAttr.ToString() : data.PropertyName;
                var extDivAttr = new Dictionary<string, string>();// { { "id", name } };

                if (attrValues != null && attrValues.Keys.Any(k => string.Compare(k, "class", true) == 0))
                    extDivAttr.Add("class", attrValues["class"].ToString());

                var externalDiv = CreateTagWithClass("div", "", "multiselect", extDivAttr);
                var internalDiv1 = CreateTagWithClass("div", "", "selectBox",
                                        new Dictionary<string, string> { { "onclick", "showCheckboxes()" } });
                var selectTag = CreateTagWithClass("select", "", "",
                                        new Dictionary<string, string> { { "id", name } });
                var optTag = CreateTagWithClass("option", "Tek veya daha seçenekler seçiniz");
                var internInternalDiv = CreateTagWithClass("div", "", "overSelect");
                var boxesDiv = CreateTagWithClass("div", "", "",
                                        new Dictionary<string, string>
                                        {
                                            { "id", "checkboxes" }, { "class", "dropdownlistboxes" }
                                        });

                var sb1 = new StringBuilder();

                foreach (var elm in selectList)
                {
                    var lblDiv = CreateTagWithClass("label", "");
                    var optChkBx = CreateTagWithClass("input", elm.Text, "",
                            new Dictionary<string, string>()
                            {
                                { "type", "checkbox" }, {"value", elm.Value}
                            });

                    var optChlBxStartTag = optChkBx.RenderStartTag().ToString();
                    var optChlBxBody = optChkBx.RenderBody().ToString();
                    var optChlBxEndTag = optChkBx.RenderEndTag().ToString();
                    var optChlBxInHtml = optChkBx.InnerHtml.ToString();

                    //lblDiv.InnerHtml.Append(optChkBx);//.ToString());

                    sb1.AppendLine(lblDiv.ToString());
                }

                boxesDiv.InnerHtml.Append(sb1.ToString()); selectTag.InnerHtml.Append(optTag.ToString());

                var sb2 = new StringBuilder();

                sb2.AppendLine(selectTag.ToString()); sb2.AppendLine(internInternalDiv.ToString());

                internalDiv1.InnerHtml.Append(sb2.ToString());

                var sb3 = new StringBuilder();

                sb3.AppendLine(internalDiv1.ToString()); sb3.AppendLine(boxesDiv.ToString());

                externalDiv.InnerHtml.Append(sb3.ToString());

                return externalDiv.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static TagBuilder CreateTagWithClass(string tag, string val, string clsNm = null,
                                                        IDictionary<string, string> attr = null)
        {
            try
            {
                var tgBldr = new TagBuilder(tag); tgBldr.InnerHtml.Append(val);

                if (!string.IsNullOrWhiteSpace(clsNm))
                    tgBldr.AddCssClass(clsNm);

                if (attr != null && attr.Any())
                    tgBldr.MergeAttributes(attr);

                return tgBldr;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static Dictionary<string, object> GetHtmlAttributes(object htmlAttr)
        {
            Dictionary<string, object> attrs = null;

            try
            {
                if (htmlAttr != null)
                {
                    var props = htmlAttr.GetType().GetProperties();

                    attrs = new Dictionary<string, object>();

                    foreach (var prop in props)
                        attrs.Add(prop.Name, prop.GetValue(htmlAttr));
                }

                return attrs;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
