using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeneralWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string KökDizin { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            try
            {
                KökDizin = "http://" + Request.Host.Value;

                BisiparişVeriAltYapı.BisiparişVeriYardımcı.BağlantıDizesi =
                    "Data Source=.\\sqlexpr16; Initial Catalog=BisiparişVT; Persist Security Info=True; "
                    + "user id=waleed; password=AbcXyz123;";

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

        public static async Task YeniKullanıcıEkle()
        {
            try
            {
                var yeniKullanıcı = new Kullanıcı()
                {
                    AktifMi = true, OluşturuKimsiId = 1, Oluşturulduğunda = DateTime.Now,
                    AdSoyad = "Waleed AlGhadamsy", Cinsiyet = BisiparişÇekirdek.Valıklar.Esansiyel.Cinsiyet.Erkek, 
                    Rol = KullanıcıRol.SistemYönetici,
                    SistemDurum = KullanıcıSistemDurum.Aktif,
                    Girişİsim = "waleed1", AsılŞifre = "AbcXyz123"
                };

                //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Saving user...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

                var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Kullanıcı>();

                yeniKullanıcı.KarmaŞifre = pwdHasher.HashPassword(yeniKullanıcı, yeniKullanıcı.AsılŞifre);

                var rslt = await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.YeniKullanıcıEkle(yeniKullanıcı);
            }
            catch (Exception ex)
            {
                //await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public async Task CheckLoginWithHash(string loginName, string password)
        {
            try
            {
                var klnc = await BisiparişVeriAltYapı.GüvenlikVeriYardımcı.Giriş(loginName);

                if (klnc != null)
                {
                    var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Kullanıcı>();
                    var sonuç = pwdHasher.VerifyHashedPassword(klnc, klnc.KarmaŞifre, password);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
