using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGet()
        {
            //var a = Url.Action("AnotherOperation", "TestLab");
            //var v = Url.RouteUrl("TestLab/AnotherOperation");
            RootDirectory = Request.Host.Value;

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
    }
}
