using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Yardımcılar
{
    public class İdariBölümlerYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        private static string İdariBölümlerUrl => $"{BisiparişWebYardımcı.ArkaUçHizmetUrl}/İdariBölümler";
        public static List<İl> İller => BisiparişWebYardımcı.MemCache.Get("İller") as List<İl>;
        public static List<İlçe> İlçeler => BisiparişWebYardımcı.MemCache.Get("İlçeler") as List<İlçe>;
        public static List<Semt> Semtler => BisiparişWebYardımcı.MemCache.Get("Semtler") as List<Semt>;
        public static List<Mahalle> Mahalleler => BisiparişWebYardımcı.MemCache.Get("Mahalleler") as List<Mahalle>;
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
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<List<SelectListItem>> İllerHazırla()
        {
            List<SelectListItem> iller = new List<SelectListItem>();

            try
            {
                //var tümİller = MemCache.Get<List<İl>>("Tümİller");

                iller.Add(new SelectListItem() { Value = "0", Text = "(İl seçiniz)", Selected = true });

                foreach (var il in İller)
                    iller.Add(new SelectListItem() { Value = $"{il.Id}", Text = $"{il.Ad}" });

                return iller;
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static void BaşkaİdariBölümlerAl()
        {
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                        using (var istemci = new System.Net.Http.HttpClient())
                        {
                            var jsonStrİlçeler = await istemci.GetStringAsync(İdariBölümlerUrl + "/İlçeler");
                            var jsonStrSemtler = await istemci.GetStringAsync(İdariBölümlerUrl + "/Semtler");
                            var jsonStrMahalleler = await istemci.GetStringAsync(İdariBölümlerUrl + "/Mahalleler");

                            if (!string.IsNullOrWhiteSpace(jsonStrİlçeler))
                                BisiparişWebYardımcı.MemCache.Set("İlçeler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlçe>>(jsonStrİlçeler));

                            if (!string.IsNullOrWhiteSpace(jsonStrSemtler))
                                BisiparişWebYardımcı.MemCache.Set("Semtler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<Semt>>(jsonStrSemtler));

                            if (!string.IsNullOrWhiteSpace(jsonStrMahalleler))
                                BisiparişWebYardımcı.MemCache.Set("Mahalleler", Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mahalle>>(jsonStrMahalleler));
                        }
                    }
                    catch (Exception ex)
                    {
                        await BisiparişWebYardımcı.HataKaydet(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await BisiparişWebYardımcı.HataKaydet(ex));
                throw ex;
            }
        }

        public static async Task<List<İl>> İlçelerOlanİllerAl()
        {
            try
            {
                await BisiparişWebYardımcı.AyıklamaKaydet("Into...");

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + "/İlçelerOlanİller");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İl>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        //public static async Task<List<İlçe>> İlİlçelerAl(int ilPlaka)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient() { })
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return JsonSerializer.Deserialize(jsonStr, typeof(List<İlçe>)) as List<İlçe>;
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

        public static async Task<List<İlçe>> İlİlçelerAl2(int ilId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlçe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        //public static async Task<List<İlçe>> İlİlçelerAl3(int ilPlaka)
        //{
        //    try
        //    {
        //        using (var istemci = new System.Net.Http.HttpClient() { })
        //        {
        //            var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlİlçeler/{ilPlaka}");

        //            if (!string.IsNullOrWhiteSpace(jsonStr))
        //                return JsonSerializer.Deserialize<List<İlçe>>(jsonStr, new JsonSerializerOptions() 
        //                { Converters = { new ListJsonConverter<İlçe>() } } );
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public static async Task<List<Semt>> İlçeSemtlerAl(int ilçeId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient() { })
                {
                    var jsonStr = await istemci.GetStringAsync(İdariBölümlerUrl + $"/İlçeSemtler/{ilçeId}");

                    //await GünlükKaydetme(OlaySeviye.Uyarı, $"Semtler: {jsonStr}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Semt>>(jsonStr);
                    //JsonSerializer.Deserialize<List<İlçe>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
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
                await BisiparişWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
        #endregion
    }
}
