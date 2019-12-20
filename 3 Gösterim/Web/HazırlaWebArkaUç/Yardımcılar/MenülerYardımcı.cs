using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace HazırlaWebArkaUç.Yardımcılar
{
    public class MenülerYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        private static string MenülerUrl => $"{HazırlaWebYardımcı.ArkaUçHizmetUrl}/Menüler";
        //public static Dictionary<int, List<Kategori>> Restoranlar
        #endregion
        //
        #region Methods (Metotlar) (Yöntemler)
        public static async Task<İcraSonuç> YeniKategoriEkle(Kategori yeniKategori)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl + "/YeniMenüKategoriEkle",
                        HazırlaWebYardımcı.JsonİçerikOluştur(yeniKategori));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        await HazırlaWebYardımcı.AyıklamaKaydet($"Back from saving category.");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        //return snç;
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
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniKategorilerEkle(List<Kategori> yeniKategoriler)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet($"Into...");

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl + "/YeniMenüKategorilerEkle",
                        HazırlaWebYardımcı.JsonİçerikOluştur(yeniKategoriler));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        await HazırlaWebYardımcı.AyıklamaKaydet("Back from saving categories.");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        //return snç;
                    }
                    else
                    {
                        await HazırlaWebYardımcı.AyıklamaKaydet("Something wrong after saving categories.");
                        //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<List<Kategori>> RestoranMenüKategorilerAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/RestoranMenüKategorilerAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                    {
                        //HazırlaWebYardımcı.Session.SetString($"Rstrn_{restoranId}_MnüKtgrlr", jsonStr);
                        HazırlaWebYardımcı.MemCache.Set($"Rstrn_{restoranId}_MnüKtgrlr", jsonStr);

                        //var ktgrlr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kategori>>(jsonStr);
                        var ktgrlr = System.Text.Json.JsonSerializer.Deserialize<List<Kategori>>(jsonStr,
                                        new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        
                        return ktgrlr;
                    }
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
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<Menü>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<Menü>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<List<Menü>> YeniMenülerAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/YeniMenülerAl");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menü>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Menü>>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniMenüEkle(Menü yeniMenü)
        {
            try
            {
                yeniMenü.SistemDurum = VarlıkSistemDurum.Aktif;
                yeniMenü.OluşturuKimsiId = Yardımcılar.GüvenlikYardımcı.ŞimdikiKullanıcıId; yeniMenü.Oluşturulduğunda = DateTime.Now;

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl + "/YeniMenüEkle", HazırlaWebYardımcı.JsonİçerikOluştur(yeniMenü));

                    if (msj.Content != null)
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<İcraSonuç> MenüOnayla(int menüId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl + "/MenüOnayla",
                                                            HazırlaWebYardımcı.JsonİçerikOluştur(menüId));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<İcraSonuç> MenüReddet(int menüId, string sebep)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(MenülerUrl + "/MenüReddet",
                                    HazırlaWebYardımcı.JsonİçerikOluştur(new List<string>() { menüId.ToString(), sebep }));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüDeğiştir(Menü menü)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PutAsync(MenülerUrl, HazırlaWebYardımcı.JsonİçerikOluştur(menü));

                    if (msj.Content != null)
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<List<Menü>> RestoranMenülerAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(MenülerUrl + $"/RestoranMenülerAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menü>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Menü>>(jsonStr,
                            new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
        #endregion
    }
}
