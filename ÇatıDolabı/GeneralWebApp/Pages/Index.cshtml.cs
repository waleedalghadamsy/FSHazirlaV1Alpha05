using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using BisiparişÇekirdek.Valıklar.Esansiyel;
//using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
//using HazırlaÇekirdek.Valıklar.Güvenlik;
//using HazırlaÇekirdek.Valıklar.Esansiyel;

namespace GeneralWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ExmplApiClient xmplClient; 

        [BindProperty]
        public string KökDizin { get; set; }

        //public IndexModel(ILogger<IndexModel> logger, ExmplApiClient apiClient)
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger; //xmplClient = apiClient;
        }

        public ActionResult OnGet()
        {
            try
            {
                KökDizin = "http://" + Request.Host.Value;

                //LocalRedirect("/AnotherExample");

                return Page();// LocalRedirect("/NestedLevel/CheckThis");

                //var r = await xmplClient.GetGreeting("Waleed");
                //var r = await WebAppHelper.ExmplClient.GetGreeting("Waleed");

                //using (var client = new System.Net.Http.HttpClient())
                //{
                //    //await HazırlaWebYardımcı.AyıklamaKaydet($"Getting users... {GüvenlikHizmetUrl}");

                //    var jsonStr = await client.GetStringAsync("http://localhost:37173/api/Example/?name=Waleed");
                //    var rslt = !string.IsNullOrWhiteSpace(jsonStr) ? "OK" : "(null)";

                //    //await HazırlaWebYardımcı.AyıklamaKaydet($"Back from service -- {rslt}");
                //}

                //WebAppHelper.Cache.Set("Example", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

                //BisiparişVeriAltYapı.BisiparişVeriYardımcı.BağlantıDizesi =
                //    "Data Source=.\\sqlexpress; Initial Catalog=BisiparişVT; Persist Security Info=True; "
                //    + "user id=waleed; password=AbcXyz123;";

                //KategorilerAyıkla();

                //Newtonsoft.Json.Linq.JArray dsrObj = (Newtonsoft.Json.Linq.JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(
                //    "[{\"Kategori\":\"kkk\",\"Alt Kategori\":\"\"},{\"Kategori\":\"mmm\",\"Alt Kategori\":\"nnn\"},{\"Kategori\":\"hhh\",\"Alt Kategori\":\"\"}]");

                //foreach(var tk in dsrObj)
                //{
                //    foreach(var chTk in tk.Children())
                //    {
                //        var chld = chTk as Newtonsoft.Json.Linq.JProperty;
                //        var nm = chld.Name; var v = chld.Value;
                //    }
                //}

                //var i = 1;
                //dsrObj[0].

                //var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(new Tuple<int, int>(4, 2));

                //var parms = new List<string>();

                //parms.Add("4"); parms.Add("2");
                //var strCnt = new System.Net.Http.StringContent(
                //    Newtonsoft.Json.JsonConvert.SerializeObject(parms),
                //    System.Text.Encoding.UTF8, "application/json");

                //using (var istemci = new System.Net.Http.HttpClient())
                //{
                //    var msj = await istemci.PostAsync("http://localhost:23458/api/Kullanıcılar/KullanıcıRestoranKaydet", strCnt);
                //}

                //await YeniKullanıcıEkle();

                //await CheckLoginWithHash("waleed1", "AbcXyz123");

                //var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
                //var hashedPwd = pwdHasher.HashPassword(new string('a', 2), "AbcXyz123");

                //var pwdHasher2 = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
                //var hashedPwd2 = pwdHasher.HashPassword(new string('a', 2), "XyzAbc123");

                //var vrfr = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
                //var rslt = vrfr.VerifyHashedPassword(new string('b', 5), hashedPwd, "AbcXyz123");
                //var rslt2 = vrfr.VerifyHashedPassword(new string('b', 5), hashedPwd2, "AbcXyz123");
                //var rslt3 = vrfr.VerifyHashedPassword(new string('b', 5), hashedPwd2, "XyzAbc123");

                //var req = new System.Net.Http.HttpClient();
                //var resp = await req.GetAsync("https://goo.gl/maps/LYuFtL5HFUyHSNqV8");

                //var uri = resp.RequestMessage.RequestUri;

                //var strUrl = uri.AbsoluteUri;
                //var atLoc = strUrl.IndexOf('@'); var zLoc = strUrl.Substring(atLoc).IndexOf('z');
                //var coords = strUrl.Substring(atLoc + 1, zLoc);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //private List<Kategori> KategorilerAyıkla()
        //{
        //    List<Kategori> ktgrlr = null;

        //    try
        //    {
        //        var yeniKtgrlr = "[{\"Kategori\":\"kkk\",\"Alt Kategori\":\"\"},"
        //            + "{\"Kategori\":\"mmm\",\"Alt Kategori\":\"nnn\"},"
        //            + "{\"Kategori\":\"mmm\",\"Alt Kategori\":\"ppp\"},"
        //            + "{\"Kategori\":\"hhh\",\"Alt Kategori\":\"\"},"
        //            + "{\"Kategori\":\"ddd\",\"Alt Kategori\":\"fff\"},"
        //            + "{\"Kategori\":\"ddd\",\"Alt Kategori\":\"sss\"}]";

        //        if (!string.IsNullOrWhiteSpace(yeniKtgrlr))
        //        {
        //            ktgrlr = new List<Kategori>();

        //            var jsnKatgrlr = Newtonsoft.Json.JsonConvert.DeserializeObject(yeniKtgrlr) as Newtonsoft.Json.Linq.JArray;
        //            Kategori birKat = null;

        //            foreach (var jsnKtg in jsnKatgrlr)
        //            {
        //                var ktProp = jsnKtg.First as Newtonsoft.Json.Linq.JProperty;
        //                var alktProp = jsnKtg.Last as Newtonsoft.Json.Linq.JProperty;
        //                var katAd = ktProp.Value.ToString();

        //                var katVar = ktgrlr.FirstOrDefault(k => k.Ad.Equals(katAd));

        //                if (katVar == null)
        //                {
        //                    birKat = new Kategori()
        //                    {
        //                        Ad = katAd,
        //                        //RestoranId = RestoranSeçildi,
        //                        SistemDurum = VarlıkSistemDurum.Aktif,
        //                        //OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
        //                        Oluşturulduğunda = DateTime.Now,
        //                        AltKategoriler = new List<Kategori>()
        //                    };

        //                    ktgrlr.Add(birKat);
        //                }
        //                else
        //                    birKat = katVar;

        //                if (alktProp.Value != null && !string.IsNullOrWhiteSpace(alktProp.Value.ToString()))
        //                    birKat.AltKategoriler.Add(
        //                        new Kategori()
        //                        {
        //                            Ad = alktProp.Value.ToString(),
        //                            //RestoranId = RestoranSeçildi,
        //                            SistemDurum = VarlıkSistemDurum.Aktif,
        //                            //OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
        //                            Oluşturulduğunda = DateTime.Now
        //                        });
        //            }
        //        }

        //        return ktgrlr;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public static async Task YeniKullanıcıEkle()
        //{
        //    try
        //    {
        //        HazırlaVeriAltYapı.HazırlaVeriYardımcı.BağlantıDizesi = "User ID = waleed; Password = AbcXyz123; Server = localhost; "
        //            + "Port = 5432; Database = hazırlavt; Integrated Security = true; Pooling = true;";

        //        var yeniKullanıcı = new Kullanıcı()
        //        {
        //            SistemDurum = VarlıkSistemDurum.Aktif,
        //            OluşturuKimsiId = 1,
        //            Oluşturulduğunda = DateTime.Now,
        //            AdSoyad = "Waleed AlGhadamsy",
        //            Cinsiyet = Cinsiyet.Erkek,
        //            Pozisyon = "Sistem Yönetici",
        //            Rol = KullanıcıRol.SistemYönetici,
        //            Girişİsim = "waleed",
        //            AsılŞifre = "AbcXyz123"
        //        };

        //        //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Saving user...");
        //        //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

        //        var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Kullanıcı>();

        //        //yeniKullanıcı.KarmaŞifre = pwdHasher.HashPassword(yeniKullanıcı, yeniKullanıcı.AsılŞifre);

        //        //var rslt = await HazırlaVeriAltYapı.GüvenlikVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı);

        //        var yeniKullanıcı1 = new Kullanıcı()
        //        {
        //            SistemDurum = VarlıkSistemDurum.Aktif,
        //            OluşturuKimsiId = 1,
        //            Oluşturulduğunda = DateTime.Now,
        //            AdSoyad = "Fatih Sönmez",
        //            Cinsiyet = Cinsiyet.Erkek,
        //            Pozisyon = "Sistem Yönetici",
        //            Rol = KullanıcıRol.SistemYönetici,
        //            Girişİsim = "fatih",
        //            AsılŞifre = "AbcXyz123"
        //        };

        //        yeniKullanıcı1.KarmaŞifre = pwdHasher.HashPassword(yeniKullanıcı1, yeniKullanıcı1.AsılŞifre);

        //        await HazırlaVeriAltYapı.GüvenlikVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı1);
        //    }
        //    catch (Exception ex)
        //    {
        //        //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
        //        throw ex;
        //    }
        //}

        //public async Task CheckLoginWithHash(string loginName, string password)
        //{
        //    try
        //    {
        //        var klnc = await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.Giriş(loginName);

        //        if (klnc != null)
        //        {
        //            var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Kullanıcı>();
        //            var sonuç = pwdHasher.VerifyHashedPassword(klnc, klnc.KarmaŞifre, password);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
