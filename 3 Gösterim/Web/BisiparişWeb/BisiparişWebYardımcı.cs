using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using System.Text.Json;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using Microsoft.AspNetCore.Http;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb
{
    public enum İcraOperasyon
    {
        Kaydetmek = 1,
        Yüklemek,
        Aramak,
        Giriş
    }

    public enum Sunucuİşlem
    {
        YeniRestoranKaydetmek = 1,
        RestoranOnayReddet,
        RestoranDeğiştirmek,
        YeniMenüKaydetmek,
        MenüOnayReddet,
        MenüDeğiştirmek,
        YeniKategoriKaydetmek,
        KategoriDeğiştirmek,
        SiparişDeğiştirmek,
        YeniKullanıcıKaydetmek,
        KullanıcıDeğiştirmek,
        YeniYardımİstekKaydetmek,
    }

    public class BisiparişWebYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        static BisiparişWebYardımcı()
        {
            KullanıcılarYeniRestoranHizmetler = new Dictionary<int, RestoranHizmetler>();

            //İşlemlerDurumlar = new Dictionary<string, bool>();
        }
        #endregion

        #region Properties (Özellikler)
        public static string KökDizin { get; set; }
        public static string AppVersion { get; set; }
        //public static Dictionary<string, bool> İşlemlerDurumlar { get; set; }
        public static string ArkaUçHizmetUrl { get; set; }
        public static string MaliHizmetUrl { get; set; }
        public static string GünlükHizmetUrl { get; set; }
        //private static string KullanıcılarUrl => $"{GüvenlikHizmetUrl}/Kullanıcılar";
        //private static string İdariBölümlerUrl => $"{ArkaUçHizmetUrl}/İdariBölümler";
        
        private static string İletişimUrl => $"{ArkaUçHizmetUrl}/İletişim";
        private static string GünlüklerUrl => $"{GünlükHizmetUrl}/Günlükçü";
        public static ISession Session { get; set; }
        public static IMemoryCache MemCache { get; set; }
        //public static IDistributedCache MemCache { get; set; }
        //public static bool KullanıcıGirişYaptıMı
        //{
        //    get
        //    {
        //        return Session.Keys.Contains("GirişYaptıMı") ? Session.GetString("GirişYaptıMı").Equals("Evet") : false;
        //    }
        //    set
        //    {
        //        if (value)
        //            Session.SetString("GirişYaptıMı", "Evet");
        //        else
        //            Session.SetString("GirişYaptıMı", "Hayır");
        //    }
        //}
        //public static Kullanıcı ŞuAnkiKullanıcı
        //{
        //    get
        //    {
        //        try
        //        {
        //            //Task.Run(async () => await GünlükKaydetme(OlaySeviye.Ayıklama, "Retrieveing user from session"));

        //            var jsonKlnc = Session.Keys.Contains("ŞuAnkiKullanıcı") ? Session.GetString("ŞuAnkiKullanıcı") : null;

        //            //Task.Run(async () => await GünlükKaydetme(OlaySeviye.Ayıklama,
        //            //        !string.IsNullOrWhiteSpace(jsonKlnc) ? jsonKlnc : "(Nothing)"));

        //            return
        //                !string.IsNullOrWhiteSpace(jsonKlnc) ? Newtonsoft.Json.JsonConvert.DeserializeObject<Kullanıcı>(jsonKlnc) : null;
        //        }
        //        catch (Exception ex)
        //        {
        //            Task.Run(async () => await GünlükKaydetme(OlaySeviye.Hata, ex.Message));

        //            return null;
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            Task.Run(async () =>
        //            {
        //                try
        //                {
        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into Session User Set");

        //                    var jsnUser = Newtonsoft.Json.JsonConvert.SerializeObject(value);

        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, $"JSON User: {jsnUser}");

        //                    Session.SetString("ŞuAnkiKullanıcı", jsnUser);

        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, "The user object is stored in session");

        //                    //var usrKey = Session.Keys.Contains("ŞuAnkiKullanıcı");

        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Is the user really in session: {usrKey}");

        //                    //var ssnUsr = Session.GetString("ŞuAnkiKullanıcı");

        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Verifying user from session: {ssnUsr}");
        //                }
        //                catch (Exception ex)
        //                {
        //                    await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //                }
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            Task.Run(async () => await GünlükKaydetme(OlaySeviye.Hata, ex.Message));
        //        }
        //    }
        //}
        //public static int ŞuAnkiKullanıcıId
        //{
        //    get
        //    {
        //        return Session.Keys.Contains("KullanıcıId") ? Session.GetInt32("KullanıcıId").Value : -1;
        //    }
        //    set
        //    {
        //        Session.SetInt32("KullanıcıId", value);
        //    }
        //}
        //public static string ŞimdikiKullanıcıİsim
        //{
        //    get
        //    {
        //        try
        //        {
        //            var isSessionAvailable = Session != null ? "OK" : "(NULL)";

        //            //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into..."));
        //            //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama,
        //            //    $"Session obj: {isSessionAvailable}"));

        //            return Session.Keys.Contains("Kullanıcıİsim") ? Session.GetString("Kullanıcıİsim") : "(Hiç kimse)";
        //        }
        //        catch (Exception ex)
        //        {
        //            Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
        //            return "(ERROR!)";
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Setting user name..."));
        //            Session.SetString("Kullanıcıİsim", value);
        //        }
        //        catch (Exception ex)
        //        {
        //            Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
        //        }
        //    }
        //}
        //public static bool ŞuAnkiKullanıcıSistemYöneticiMi =>  ŞuAnkiKullanıcı.Rol == KullanıcıRol.SistemYönetici;
        //public static bool ŞuAnkiKullanıcıİşletmeYöneticiMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeYönetici;
        //public static bool ŞuAnkiKullanıcıDestekTemsilciMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.MüşteriDestekTemsilci;
        //public static bool ŞuAnkiKullanıcıİşletmeKullanıcıMı => ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeKullanıcı;
        //public static bool ŞuAnkiKullanıcıMüşteriMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.Müşteri;
        //public static string ŞuAnkiKullanıcıMenüKısmiGörüntü { get; set; }
        //public static List<İl> Tümİller => MemCache.Get("Tümİller") as List<İl>;
        //public static List<İl> İller => MemCache.Get("İller") as List<İl>;
        //public static List<İlçe> İlçeler => MemCache.Get("İlçeler") as List<İlçe>;
        //public static List<Semt> Semtler => MemCache.Get("Semtler") as List<Semt>;
        //public static List<Mahalle> Mahalleler => MemCache.Get("Mahalleler") as List<Mahalle>;
        //public static List<SelectListItem> KullanıcıRolar { get; set; }
        
        public static Dictionary<int, RestoranHizmetler> KullanıcılarYeniRestoranHizmetler { get; set; }
        public static RestoranHizmetler ŞuAnkiKullanıcıYeniRestoranHizmetler { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static void EsansyelVarlıklarYükle()
        {
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Getting all iller with sub...");

                        MemCache.Set("İller", await Yardımcılar.İdariBölümlerYardımcı.İllerAl());

                        //List<İl> sdciller;
                        //MemCache.TryGetValue("İller", out sdciller);
                        //var nIller = sdciller != null ? $"{sdciller.Count}" : "(NULL)";
                        //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Got: {nIller}");

                        Yardımcılar.İdariBölümlerYardımcı.BaşkaİdariBölümlerAl();

                        //await Yardımcılar.GüvenlikYardımcı.KullanıcılarAl();

                        //var mmch = MemCache != null ? "OK" : "(NULL)";
                        //await GünlükKaydetme(OlaySeviye.Ayıklama, $"MemCache: {mmch}");

                        //MemCache.Set("Tümİller", alliller);// await İlçelerOlanİllerAl());
                    }
                    catch (Exception ex)
                    {
                        await GünlükKaydet(OlaySeviye.Hata, ex);
                        throw ex;
                    }
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await GünlükKaydet(OlaySeviye.Hata, ex));
                throw ex;
            }
        }

        //public static async Task<List<İl>> İllerAl()
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + "/İller");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İl>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public static async Task<List<SelectListItem>> İllerHazırla()
        //{
        //    List<SelectListItem> iller = new List<SelectListItem>();

        //    try
        //    {
        //        //var tümİller = MemCache.Get<List<İl>>("Tümİller");

        //        iller.Add(new SelectListItem() { Value = "0", Text = "(İl seçiniz)", Selected = true });

        //        foreach (var il in İller)
        //            iller.Add(new SelectListItem() { Value = $"{il.Id}", Text = $"{il.Ad}" });

        //        return iller; 
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static void BaşkaİdariBölümlerAl()
        //{
        //    try
        //    {
        //        Task.Run(async () =>
        //            {
        //                try
        //                {
        //                    //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

        //                    using (var istemci = new System.Net.Http.HttpClient())
        //                    {
        //                        var jsonStrİlçeler = await istemci.GetStringAsync(İdariBölümlerUrl + "/İlçeler");
        //                        var jsonStrSemtler = await istemci.GetStringAsync(İdariBölümlerUrl + "/Semtler");
        //                        var jsonStrMahalleler = await istemci.GetStringAsync(İdariBölümlerUrl + "/Mahalleler");

        //                        if (!string.IsNullOrWhiteSpace(jsonStrİlçeler))
        //                            MemCache.Set("İlçeler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlçe>>(jsonStrİlçeler));

        //                        if (!string.IsNullOrWhiteSpace(jsonStrSemtler))
        //                            MemCache.Set("Semtler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<Semt>>(jsonStrSemtler));

        //                        if (!string.IsNullOrWhiteSpace(jsonStrMahalleler))
        //                            MemCache.Set("Mahalleler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mahalle>>(jsonStrMahalleler));
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //                }
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        Task.Run(async () => await GünlükKaydetme(OlaySeviye.Hata, ex.Message));
        //        throw ex;
        //    }
        //}

        //public static async Task<List<İl>> İlçelerOlanİllerAl()
        //{
        //    try
        //    {
        //        await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + "/İlçelerOlanİller");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İl>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        ////public static async Task<List<İlçe>> İlİlçelerAl(int ilPlaka)
        ////{
        ////    try
        ////    {
        ////        using (var istemci = new System.Net.Http.HttpClient() { })
        ////        {
        ////            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

        ////            if (!string.IsNullOrWhiteSpace(jsonStr))
        ////                return JsonSerializer.Deserialize(jsonStr, typeof(List<İlçe>)) as List<İlçe>;
        ////            //JsonSerializer.Deserialize<List<İlçe>>(jsonStr);
        ////            else
        ////                return null;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        throw;
        ////    }
        ////}

        //public static async Task<List<İlçe>> İlİlçelerAl2(int ilId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilId}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlçe>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        ////public static async Task<List<İlçe>> İlİlçelerAl3(int ilPlaka)
        ////{
        ////    try
        ////    {
        ////        using (var istemci = new System.Net.Http.HttpClient() { })
        ////        {
        ////            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

        ////            if (!string.IsNullOrWhiteSpace(jsonStr))
        ////                return JsonSerializer.Deserialize<List<İlçe>>(jsonStr, new JsonSerializerOptions() 
        ////                { Converters = { new ListJsonConverter<İlçe>() } } );
        ////            else
        ////                return null;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        throw;
        ////    }
        ////}

        //public static async Task<List<Semt>> İlçeSemtlerAl(int ilçeId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient() { })
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlçeSemtler/{ilçeId}");

        //            //await GünlükKaydetme(OlaySeviye.Uyarı, $"Semtler: {jsonStr}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Semt>>(jsonStr);
        //            //JsonSerializer.Deserialize<List<İlçe>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        ////public static async Task<List<Semt>> İlçeSemtlerAl(int ilçId)
        ////{
        ////    try
        ////    {
        ////        using (var istemci = new System.Net.Http.HttpClient())
        ////        {
        ////            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlçeSemtler/{ilçId}");

        ////            if (!string.IsNullOrWhiteSpace(jsonStr))
        ////                return System.Text.Json.JsonSerializer.Deserialize<List<Semt>>(jsonStr);
        ////            else
        ////                return null;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        throw;
        ////    }
        ////}

        //public static async Task<List<Mahalle>> SemtMahallelerAl(int smtId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/SemtMahalleler/{smtId}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mahalle>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public static async Task KullanıcıRolarHazırla()
        //{
        //    try
        //    {
        //        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

        //        await Task.Run(async () =>
        //            {
        //                //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

        //                if (ŞuAnkiKullanıcı != null)
        //                {
        //                    if (ŞuAnkiKullanıcı.Rol == KullanıcıRol.SistemYönetici)
        //                    {
        //                        KullanıcıRolar = new List<SelectListItem>()
        //                        {
        //                            new SelectListItem() { Value = "0", Text = "(Rol seçiniz)", Selected = true },
        //                            new SelectListItem() { Value = "1", Text = "Sistem Yönetici" },
        //                            new SelectListItem() { Value = "2", Text = "Müşteri Destek Temsilci" },
        //                            new SelectListItem() { Value = "3", Text = "İşletme Yönetici" },
        //                            new SelectListItem() { Value = "4", Text = "İşletme Çalışan" }
        //                        };
        //                    }
        //                    else if (ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeYönetici)
        //                    {
        //                        KullanıcıRolar = new List<SelectListItem>()
        //                        {
        //                            new SelectListItem() { Value = "0", Text = "(Rol seçiniz)", Selected = true },
        //                            new SelectListItem() { Value = "3", Text = "İşletme Yönetici" },
        //                            new SelectListItem() { Value = "4", Text = "İşletme Çalışan" }
        //                        };
        //                    }
        //                }
        //                else
        //                    await GünlükKaydetme(OlaySeviye.Ayıklama, "User is null!!!");
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static async Task<Kullanıcı> Giriş(string girişİsim, string şifre)
        //{
        //    try
        //    {
        //        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

        //        var k = new Kullanıcı() { Id = 5, Girişİsim = girişİsim, Rol = KullanıcıRol.İşletmeKullanıcı, AdSoyad = "Ameen" };

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            //Hem giriş isim hem de şifre tek bir nesne olarak gönderme
        //            var girişİsimVeŞifre = $"{girişİsim} <||> {şifre}";

        //            var jsonStr = await istemci.GetStringAsync(KullanıcılarUrl + $"/Giriş/{girişİsimVeŞifre}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<Kullanıcı>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static async Task KullanıcıGirişti(Kullanıcı kullanıcı)
        //{
        //    try
        //    {
        //        ŞuAnkiKullanıcı = kullanıcı; ŞuAnkiKullanıcıId = kullanıcı.Id; ŞimdikiKullanıcıİsim = kullanıcı.AdSoyad;
        //        KullanıcıGirişYaptıMı = true;

        //        await KullanıcıRolarHazırla();
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static async Task<bool> GirişİsimZatenKullanıldıMı(string girişİsim)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(KullanıcılarUrl + $"/GirişİsimZatenKullanıldıMı/{girişİsim}");

        //            return Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(jsonStr);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        ////public static async Task Çıkış()
        ////{
        ////    try
        ////    {
        ////        Session.Clear();
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        throw ex;
        ////    }
        ////}

        //public static async Task<İcraSonuç> YeniKullanıcıEkle(Kullanıcı yeniKullanıcı)
        //{
        //    try
        //    {
        //        yeniKullanıcı.AktifMi = true;
        //        yeniKullanıcı.OluşturuKimsiId = ŞuAnkiKullanıcıId; yeniKullanıcı.Oluşturulduğunda = DateTime.Now;

        //        await GünlükKaydetme(OlaySeviye.Ayıklama, "Saving user...");
        //        //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var msj = await istemci.PostAsync(KullanıcılarUrl + "/YeniKullanıcıEkle", JsonİçerikOluştur(yeniKullanıcı));

        //            if (msj.Content != null)
        //            {
        //                //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //                //var cntTp = msj.Content.Headers.ContentType.ToString();

        //                //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //            }
        //            else
        //            {
        //                //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");

        //                return null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static async Task<İcraSonuç> KullanıcıDegiştir(Kullanıcı kullanıcı)
        //{
        //    try
        //    {
        //        await GünlükKaydetme(OlaySeviye.Ayıklama, "Modifying user...");
        //        //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var msj = await istemci.PostAsync(KullanıcılarUrl + "/KullanıcıDegiştir", JsonİçerikOluştur(kullanıcı));

        //            if (msj.Content != null)
        //            {
        //                //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //                //var cntTp = msj.Content.Headers.ContentType.ToString();

        //                //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //            }
        //            else
        //            {
        //                //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");

        //                return null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        //public static async Task<İcraSonuç> ŞifreDegiştir(Kullanıcı kullanıcı, string şifre)
        //{
        //    try
        //    {
        //        await GünlükKaydetme(OlaySeviye.Ayıklama, "Changing password...");
        //        //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

        //        kullanıcı.Şifre = şifre;

        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var msj = await istemci.PostAsync(KullanıcılarUrl + "/ŞifreDegiştir", JsonİçerikOluştur(kullanıcı));

        //            if (msj.Content != null)
        //            {
        //                //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //                //var cntTp = msj.Content.Headers.ContentType.ToString();

        //                //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
        //            }
        //            else
        //            {
        //                //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");

        //                return null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
        //        throw ex;
        //    }
        //}

        

        //public static async Task<List<Menü>> KafeMenülerAl(int kafeId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/Kafe/{kafeId}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menü>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public static async Task<List<ElemanFotoğraf>> KafeFotoğraflarAl(int restoranId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(KafelerUrl + $"/KafeFotoğraflarAl/{restoranId}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ElemanFotoğraf>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static async Task<İşyeriİletişim> İşyeriİletişimAl(int id)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İletişimUrl + $"/{id}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İşyeriİletişim>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        //public static void SunucuİşlemBaşla(string işlemKod)
        //{
        //    try
        //    {
        //        if (!İşlemlerDurumlar.ContainsKey(işlemKod))
        //            İşlemlerDurumlar.Add(işlemKod, false);
        //        else
        //            İşlemlerDurumlar[işlemKod] = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex));
        //        throw ex;
        //    }
        //}

        //public static async Task GünlükKaydetme(Günlük günlük, 
        //    [CallerFilePath] string dosyaYolu = "", [CallerMemberName] string üyeAd = "")
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            if (!string.IsNullOrWhiteSpace(dosyaYolu) || !string.IsNullOrWhiteSpace(üyeAd))
        //                günlük.Kaynak = $"{dosyaYolu} | {üyeAd}";

        //            await istemci.PostAsync(GünlüklerUrl, JsonİçerikOluştur(günlük));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //private static void ŞifreKarışma(Kullanıcı kullanıcı, string şifre)
        //{
        //    try
        //    {
        //        var pwdHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Kullanıcı>();

        //        pwdHasher.HashPassword(kullanıcı, şifre);
        //        var rslt = pwdHasher.VerifyHashedPassword(kullanıcı, "", "");
        //        //if (rslt == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
        //    }
        //    catch (Exception ex)
        //    {
        //        Task.Run(async () => await GünlükKaydet(OlaySeviye.Hata, ex));
        //        throw ex;
        //    }
        //}

        //public static void KullanıcıMenüAyarla(KullanıcıRol rol)
        //{
        //    HttpContext.
        //    switch (rol)
        //    {
        //        case KullanıcıRol.SistemYönetici:
        //            BisiparişWebYardımcı.ŞuAnkiKullanıcıMenü = Partial("_SistemYöneticiMenüKısmiGörüntü");
        //            break;
        //        case KullanıcıRol.İşletmeYönetici:
        //            break;
        //        case KullanıcıRol.MüşteriDestekTemsilci:
        //            break;
        //        case KullanıcıRol.İşletmeKullanıcı:
        //            break;
        //    }
        //}

        public static async Task GünlükKaydet(OlaySeviye seviye, string mesaj)
        {
            try
            {
                var şimdi = DateTime.Now;
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                var günlük = new Günlük()
                {
                    Seviye = seviye,
                    Kaynak = $"{methodContainer.FullName}.{method.Name}",
                    Mesaj = mesaj,
                    Tarih = şimdi.ToString("dd-MM-yyyy"),
                    Zaman = şimdi.ToString("HH:mm:ss.fffff")
                };

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var result = await istemci.PostAsync(GünlüklerUrl, JsonİçerikOluştur(günlük));
                    //var result = await istemci.PostAsync(GünlüklerUrl + "/OnlyForTest", JsonİçerikOluştur("First trial"));

                    //var msg = await result.Content.ReadAsStringAsync();
                    //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task GünlükKaydet(OlaySeviye seviye, Exception ex)
        {
            try
            {
                var şimdi = DateTime.Now;
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                var günlük = new Günlük()
                {
                    Seviye = seviye,
                    Kaynak = $"{methodContainer.FullName}.{method.Name}",
                    Mesaj = GetInnerExceptions(ex),
                    Tarih = şimdi.ToString("dd-MM-yyyy"),
                    Zaman = şimdi.ToString("HH:mm:ss.fffff")
                };

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var result = await istemci.PostAsync(GünlüklerUrl, JsonİçerikOluştur(günlük));
                    //var result = await istemci.PostAsync(GünlüklerUrl + "/OnlyForTest", JsonİçerikOluştur("First trial"));

                    //var msg = await result.Content.ReadAsStringAsync();
                    //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public static async Task GünlükKaydet(Günlük günlük)
        {
            try
            {
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                var şimdi = DateTime.Now;
                günlük.Kaynak = $"{methodContainer.FullName}.{method.Name}";
                günlük.Tarih = şimdi.ToString("dd-MM-yyyy"); günlük.Zaman = şimdi.ToString("HH:mm:ss.fffff");

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var result = await istemci.PostAsync(GünlüklerUrl, JsonİçerikOluştur(günlük));
                    //var result = await istemci.PostAsync(GünlüklerUrl + "/OnlyForTest", JsonİçerikOluştur("First trial"));

                    //var msg = await result.Content.ReadAsStringAsync();
                    //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //private static System.Net.Http.StringContent JsonİçerikOluştur<T>(T nesne)
        //{
        //    try
        //    {
        //        var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(nesne);
        //        var içerik = new System.Net.Http.StringContent(jsonStr);
        //        içerik.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        return içerik;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static System.Net.Http.StringContent JsonİçerikOluştur(object nesne)
        {
            try
            {
                var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(nesne);

                return new System.Net.Http.StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(nesne),
                    System.Text.Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                Task.Run(async () => await GünlükKaydet(OlaySeviye.Hata, ex));
                throw ex;
            }
        }
        //private static string JsonOluştur(object nesne)
        //{
        //    try
        //    {
        //        var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(nesne);

        //        return new System.Net.Http.StringContent(
        //            Newtonsoft.Json.JsonConvert.SerializeObject(nesne),
        //            System.Text.Encoding.UTF8, "application/json");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //private static (System.Net.Http.StringContent, string) JsonİçerikOluşturWithStr(object nesne)
        //{
        //    try
        //    {
        //        var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(nesne, new Newtonsoft.Json.JsonSerializerSettings()
        //        {
        //            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        //        });

        //        return (new System.Net.Http.StringContent(
        //            Newtonsoft.Json.JsonConvert.SerializeObject(nesne), 
        //            System.Text.Encoding.UTF8, "application/json"), jsonObj);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static string OpSonuçMesajAl(İcraOperasyon operasyon, İcraSonuç icraSonuç)
        {
            try
            {
                var snc = icraSonuç != null ? icraSonuç.BaşarılıMı.ToString() : "(NULL)";
                Task.Run(async () => await GünlükKaydet(OlaySeviye.Ayıklama, $"Getting friendly msg: {snc}"));

                if (icraSonuç != null)
                    switch (operasyon)
                    {
                        case İcraOperasyon.Yüklemek:
                            return "";
                        case İcraOperasyon.Kaydetmek:
                            var rslt = icraSonuç != null ? icraSonuç.Mesaj : "(null)";
                            Task.Run(async () => await GünlükKaydet(OlaySeviye.Ayıklama, $"Save result: {operasyon} --> {rslt}"));

                            return icraSonuç.BaşarılıMı
                                ? "<label style='color:green'>Başarıyla kaydedildi.</label>"
                                : $"<label style='color:red'>Pardon! Bir hata var.</label>";
                        case İcraOperasyon.Aramak:
                            return "";
                        default:
                            return "";
                    }
                else
                    return $"<label style='color:red'>Pardon! Bir hata var.</label>";
            }
            catch (Exception ex)
            {
                Task.Run(async () => await GünlükKaydet(OlaySeviye.Hata, ex));
                throw;
            }
        }

        private static string GetInnerExceptions(Exception ex)
        {
            string exceptionMessage = string.Format("[{2}] Message: {0} {1}", ex.Message,
                                        (!string.IsNullOrWhiteSpace(ex.Source) ? "Source: " + ex.Source : ""),
                                        ex.GetType().FullName);

            if (ex.InnerException != null)
                exceptionMessage += " -- INNER: " + GetInnerExceptions(ex.InnerException);

            return exceptionMessage;
        }
        #endregion
    }
}
