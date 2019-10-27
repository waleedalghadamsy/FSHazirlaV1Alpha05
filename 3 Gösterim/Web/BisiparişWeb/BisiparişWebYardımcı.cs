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

namespace BisiparişWeb
{
    public enum İcraOperasyon
    {
        Kaydetmek = 1,
        Yüklemek,
        Aramak,
        Giriş
    }

    public class BisiparişWebYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        static BisiparişWebYardımcı()
        {
            İller = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "0", Text = "(İl seçiniz)", Selected = true },
                new SelectListItem() { Value = "34", Text = "İstanbul" },
            };

            RestoranTürlar = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "0", Text = "(Tür seçiniz)", Selected = true },
                new SelectListItem() { Value = "1", Text = "Ye ve Kalk" },
                new SelectListItem() { Value = "2", Text = "Yemek" },
                new SelectListItem() { Value = "3", Text = "Tatlıcı" },
                new SelectListItem() { Value = "4", Text = "Kahvaltı" },
                new SelectListItem() { Value = "5", Text = "Lüks Yemek" },
                new SelectListItem() { Value = "6", Text = "Lokanta" },
                new SelectListItem() { Value = "7", Text = "Cafe ve İçecek" },
                new SelectListItem() { Value = "8", Text = "Sokak Lezzetleri" },
                new SelectListItem() { Value = "9", Text = "Pastaneler" },
                new SelectListItem() { Value = "10", Text = "Romantik Mekanlar" },
            };
        }
        #endregion

        #region Properties (Özellikler)
        public static string KökDizin { get; set; }
        private static string ArkaUçHizmetUrl => "http://localhost:11001/api";
        private static string GünlükHizmetUrl => "http://localhost:11011/api";
        private static string İdariBölümlerUrl => $"{ArkaUçHizmetUrl}/İdariBölümler";
        private static string RestoranlarUrl => $"{ArkaUçHizmetUrl}/Restoranlar";
        private static string KafelerUrl => $"{ArkaUçHizmetUrl}/Kafeler";
        private static string MenülerUrl => $"{ArkaUçHizmetUrl}/Menüler";
        private static string İletişimUrl => $"{ArkaUçHizmetUrl}/İletişim";
        private static string GünlüklerUrl => $"{GünlükHizmetUrl}/Günlükçü";
        public static int ŞuAnkiKullanıcıId { get; set; }
        public static List<SelectListItem> RestoranTürlar { get; set; }
        public static List<SelectListItem> İller { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<List<İl>> İllerAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + "/İller");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İl>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İlçe>> İlİlçelerAl(int ilPlaka)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient() { })
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return JsonSerializer.Deserialize(jsonStr, typeof(List<İlçe>)) as List<İlçe>;
                    //JsonSerializer.Deserialize<List<İlçe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<İlçe>> İlİlçelerAl2(int ilPlaka)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlçe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<İlçe>> İlİlçelerAl3(int ilPlaka)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient() { })
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return JsonSerializer.Deserialize<List<İlçe>>(jsonStr, new JsonSerializerOptions() 
                        { Converters = { new ListJsonConverter<İlçe>() } } );
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<Semt>> İlçeSemtlerAl(int ilçeId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient() { })
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlçeSemtler/{ilçeId}");

                    await GünlükKaydetme(OlaySeviye.Uyarı, $"Semtler: {jsonStr}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Semt>>(jsonStr);
                    //JsonSerializer.Deserialize<List<İlçe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<(string, ICollection<string>)> GetTypeAndEncoding()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var resp = await istemci.GetAsync(İdariBölümlerUrl + $"/İlİlçeler/34");

                    return (resp.Content.Headers.ContentType.ToString(), resp.Content.Headers.ContentEncoding);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public static async Task<List<Semt>> İlçeSemtlerAl(int ilçId)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient())
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlçeSemtler/{ilçId}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return System.Text.Json.JsonSerializer.Deserialize<List<Semt>>(jsonStr);
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public static async Task<List<Mahalle>> SemtMahallelerAl(int smtId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/SemtMahalleler/{smtId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mahalle>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<Restoran>> RestoranlarAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + "/RestoranlarAl");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<Restoran> RestoranAl(int id)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/RestoranAl/{id}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Restoran>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task RestoranGerekSinimlerYükle()
        {
            try
            {
                await Task.Run(() => { });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<İcraSonuç> YeniRestoranEkle(Restoran yeniRestoran)
        {
            try
            {
                yeniRestoran.AktifMi = true; yeniRestoran.ÖzelSektörMü = true;
                yeniRestoran.OluşturuKimsiId = ŞuAnkiKullanıcıId; yeniRestoran.Oluşturulduğunda = DateTime.Now;
                yeniRestoran.Onaylı = false;

                //await GünlükKaydetme(OlaySeviye.Uyarı, "Saving restaurant...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON restaurant: " + JsonİçerikOluşturWithStr(yeniRestoran).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/YeniRestoranEkle", JsonİçerikOluştur(yeniRestoran));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                await GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> RestoranDeğiştir(Restoran restoran)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PutAsync(RestoranlarUrl + "/RestoranDeğiştir", JsonİçerikOluştur(restoran));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Kafe>> KafelerAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(KafelerUrl + "/KafelerAl");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kafe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task KafeGerekSinimlerYükle()
        {
            try
            {
                await Task.Run(() => { });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<Kafe> KafeAl(int id)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(KafelerUrl + $"/KafeAl/{id}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Kafe>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniKafeEkle(Kafe yeniKafe)
        {
            try
            {
                yeniKafe.AktifMi = true; yeniKafe.ÖzelSektörMü = true;
                yeniKafe.OluşturuKimsiId = ŞuAnkiKullanıcıId; yeniKafe.Oluşturulduğunda = DateTime.Now;
                yeniKafe.Onaylı = false;

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KafelerUrl + "/YeniKafeEkle", JsonİçerikOluştur(yeniKafe));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> KafeDeğiştir(Kafe kafe)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PutAsync(KafelerUrl + "/KafeDeğiştir", JsonİçerikOluştur(kafe));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Menü>> RestoranMenülerAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/Restoran/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menü>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<ElemanFotoğraf>> RestoranFotoğraflarAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant photos...");

                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/RestoranFotoğraflarAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ElemanFotoğraf>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Restaurant photos exp: {ex.Message}");
                throw ex;
            }
        }

        public static async Task<List<Menü>> KafeMenülerAl(int kafeId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/Kafe/{kafeId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menü>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<ElemanFotoğraf>> KafeFotoğraflarAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(KafelerUrl + $"/KafeFotoğraflarAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ElemanFotoğraf>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<Menü> MenüAl(int id)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/{id}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Menü>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniMenüEkle(Menü yeniMenü)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl, JsonİçerikOluştur(yeniMenü));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüDeğiştir(Menü menü)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PutAsync(MenülerUrl, JsonİçerikOluştur(menü));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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

                throw ex;
            }
        }

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

        public static async Task GünlükKaydetme(OlaySeviye seviye, string mesaj)
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

        public static async Task GünlükKaydetme(Günlük günlük)
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

        private static System.Net.Http.StringContent JsonİçerikOluştur(object nesne)
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

                throw ex;
            }
        }

        private static (System.Net.Http.StringContent, string) JsonİçerikOluşturWithStr(object nesne)
        {
            try
            {
                var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(nesne, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                });

                return (new System.Net.Http.StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(nesne), 
                    System.Text.Encoding.UTF8, "application/json"), jsonObj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string OpSonuçMesajAl(İcraOperasyon operasyon, İcraSonuç icraSonuç)
        {
            try
            {
                switch (operasyon)
                {
                    case İcraOperasyon.Yüklemek:
                        return "";
                    case İcraOperasyon.Kaydetmek:
                        return icraSonuç.BaşarılıMı
                            ? "<label style='color:green'>Başarıyla kaydedildi.</label>"
                            : $"<label style='color:red'>Tried saving -- {icraSonuç.Mesaj}</label>";
                    case İcraOperasyon.Aramak:
                        return "";
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        public class ListJsonConverter<T> : JsonConverter<List<T>>
        {
            public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var converter = GetKeyConverter(options);
                var key = converter.Read(ref reader, typeToConvert, options);

                return new List<T>();
            }

            public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
            {
                var converter = GetKeyConverter(options);
                converter.Write(writer, value, options);
            }

            private static JsonConverter<List<T>> GetKeyConverter(JsonSerializerOptions options)
            {
                var converter = options.GetConverter(typeof(List<T>)) as JsonConverter<List<T>>;

                if (converter is null)
                    throw new JsonException("...");

                return converter;
            }
        }

        public class ListJsonConverterFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
            {
                if (!typeToConvert.IsGenericType)
                    return false;

                var type = typeToConvert;

                if (!type.IsGenericTypeDefinition)
                    type = type.GetGenericTypeDefinition();

                return type == typeof(List<>);
            }

            public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            {
                var keyType = typeToConvert.GenericTypeArguments[0];
                var converterType = typeof(ListJsonConverter<>).MakeGenericType(keyType);

                return (JsonConverter)Activator.CreateInstance(converterType);
            }
        }
    }
}
