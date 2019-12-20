using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace HazırlaWebArkaUç.Yardımcılar
{
    public class RestoranlarYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        static RestoranlarYardımcı()
        {
            RestoranTürler = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "0", Text = "(Tür seçiniz)", Selected = true },
                new SelectListItem() { Value = "1", Text = "Ye ve Kalk" },
                new SelectListItem() { Value = "2", Text = "Yemek" },
                new SelectListItem() { Value = "4", Text = "Tatlıcı" },
                new SelectListItem() { Value = "8", Text = "Kahvaltı" },
                new SelectListItem() { Value = "16", Text = "Lüks Yemek" },
                new SelectListItem() { Value = "32", Text = "Lokanta" },
                new SelectListItem() { Value = "64", Text = "Cafe ve İçecek" },
                new SelectListItem() { Value = "128", Text = "Sokak Lezzetleri" },
                new SelectListItem() { Value = "256", Text = "Pastaneler" },
                new SelectListItem() { Value = "512", Text = "Romantik Mekanlar" },
            };

            RestoranHizmetleri = new Dictionary<RestoranHizmetler, string>()
            {
                { RestoranHizmetler.Kahvaltı, "Kahvaltı" },
                { RestoranHizmetler.TatlıVePasta, "Tatlı ve Pasta" },
                { RestoranHizmetler.EvYemeği, "Ev Yemeği" },
                { RestoranHizmetler.Brunch, "Brunch" },
                { RestoranHizmetler.LüksYemek, "Lüks Yemek" },
                { RestoranHizmetler.VeganSeçenekler, "Vegan Seçenekler" },
                { RestoranHizmetler.AçıkBüfe, "Açık Büfe" },
                { RestoranHizmetler.GrupYemeği, "Grup Yemeği" },
                { RestoranHizmetler.Mescit, "Mescit" },
                { RestoranHizmetler.ÇocukluAilelerİçinUygun, "Çocuklu Aileler İçin Uygun" },
                { RestoranHizmetler.İşYemeğiİçinUygun, "İş Yemeği İçin Uygun" },
                { RestoranHizmetler.OturmaAlanıYok, "Oturma Alanı Yok" },
                { RestoranHizmetler.İçMekan, "İç Mekan" },
                { RestoranHizmetler.DışMekan, "Dış Mekan" },
                { RestoranHizmetler.BalkonVeyaTeras, "Balkon/Teras" },
                { RestoranHizmetler.DenizKenarı, "Deniz Kenarı" },
                { RestoranHizmetler.GölKenarı, "Göl Kenarı" },
                { RestoranHizmetler.Doğaİleİçİçe, "Doğa İle İç İçe" },
                { RestoranHizmetler.ŞehirManzarası, "Şehir Manzarası" },
                { RestoranHizmetler.EngelliDostu, "Engelli Dostu" },
                { RestoranHizmetler.EvcilHayvanDostu, "Evcil Hayvan Dostu" },
                { RestoranHizmetler.VIPYemekSalonu, "VIP Yemek Salonu" },
                { RestoranHizmetler.SigaraİçmeAlanı, "Sigara İçme Alanı" },
                { RestoranHizmetler.SelfServis, "Self Servis" },
                { RestoranHizmetler.MasaHazırlat, "Masa Hazırlat" },
                { RestoranHizmetler.GelAl, "Gel Al" },
                { RestoranHizmetler.Fasıl, "Fasıl" },
                { RestoranHizmetler.Nargile, "Nargile" },
                //AlkolServisiVar,
                { RestoranHizmetler.AlkolServisiYok, "Alkol Servisi Yok" },
                { RestoranHizmetler.MasaOyunları, "Masa Oyunları" },
                { RestoranHizmetler.CanlıMüzik, "Canlı Müzik" },
                { RestoranHizmetler.MaçYayını, "Maç Yayını" },
                { RestoranHizmetler.DjPerformansı, "Dj Performansı" },
                { RestoranHizmetler.Wifi, "Wifi" },
                { RestoranHizmetler.MobilŞarjAleti, "Mobil Şarj Aleti" },
                { RestoranHizmetler.OtoparkAlanı, "Otopark Alanı" },
                { RestoranHizmetler.Vale, "Vale" },
                { RestoranHizmetler.Huzur, "Huzur" },
                { RestoranHizmetler.DoğumGünü, "DoğumGünü" }
            };

            RestoranMutfakları = new Dictionary<Mutfaklar, string>()
            {
                { Mutfaklar.BalıkVeDenizÜrünleri, "Balık & Deniz ürünleri" },
                { Mutfaklar.Börek, "Börek" },
                { Mutfaklar.Burger, "Burger" },
                { Mutfaklar.Cafe, "Cafe" },
                { Mutfaklar.ÇiğKöfte, "Çiğ Köfte" },
                { Mutfaklar.Dondurma, "Dondurma" },
                { Mutfaklar.Döner, "Döner" },
                { Mutfaklar.DünyaMutfağı, "Dünya Mutfağı" },
                { Mutfaklar.EvYemekleri, "Ev yemekleri" },
                { Mutfaklar.FastFoodVeSandwich, "Fast Food & Sandwich" },
                { Mutfaklar.AsyaMutfağıVeSushi, "Asya mutfağı & Sushi" },
                { Mutfaklar.Kahvaltı, "Kahvaltı" },
                { Mutfaklar.Kahve, "Kahve" },
                { Mutfaklar.KebapVeTürkMutfağı, "Kebap & Türk Mutfağı" },
                { Mutfaklar.Köfte, "Köfte" },
                { Mutfaklar.KokoreçVeMidye, "Kokoreç & Midye" },
                { Mutfaklar.Kumpir, "Kumpir" },
                { Mutfaklar.PastaVeTatlı, "Pasta & Tatlı" },
                { Mutfaklar.Pide, "Pide" },
                { Mutfaklar.Pilav, "Pilav" },
                { Mutfaklar.Pizza, "Pizza" },
                { Mutfaklar.Steak, "Steak" },
                { Mutfaklar.Tantuni, "Tantuni" },
                { Mutfaklar.Tavuk, "Tavuk" },
                { Mutfaklar.İtalyanMutfağı, "İtalyan Mutfağı" },
                { Mutfaklar.Nargile, "Nargile" }
             };
        }
        #endregion

        #region Properties (Özellikler)
        private static string RestoranlarUrl => $"{HazırlaWebYardımcı.ArkaUçHizmetUrl}/Restoranlar";
        public static List<SelectListItem> RestoranlarListe { get; set; }
        public static List<SelectListItem> RestoranTürler { get; set; }
        public static Dictionary<RestoranHizmetler, string> RestoranHizmetleri { get; set; }
        public static Dictionary<Mutfaklar, string> RestoranMutfakları { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<string> RestoranHizmetlerSeçeneklerHazırla()
        {
            StringBuilder seçenekler = new StringBuilder();

            try
            {
                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Preparing rest. services...");

                foreach (var hzmt in RestoranHizmetleri)
                    seçenekler.Append($"<li><a class=\"dropdown-item\" href=\"#\"><input type=\"checkbox\" name=\"{hzmt.Key}Chk\"" 
                        + $" value=\"{(long)hzmt.Key}\" onclick=\"hizmetSeçildi('{(long)hzmt.Key}', '{hzmt.Key}');\" />"
                        + $"{hzmt.Value}</a></li>");


                //await GünlükKaydetme(OlaySeviye.Ayıklama, "Select options:");
                //await GünlükKaydetme(OlaySeviye.Ayıklama, seçenekler.ToString());

                return seçenekler.ToString();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<string> RestoranMutfaktlarSeçeneklerHazırla()
        {
            StringBuilder seçenekler = new StringBuilder();

            try
            {
                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Preparing rest. services...");

                foreach (var mtfk in RestoranMutfakları)
                    seçenekler.Append($"<li><a class=\"dropdown-item\" href=\"#\"><input type=\"checkbox\" name=\"{mtfk.Key}Chk\""
                        + $" value=\"{(long)mtfk.Key}\" onclick=\"mutfakSeçildi('{(long)mtfk.Key}', '{mtfk.Key}');\" />"
                        + $"{mtfk.Value}</a></li>");

                //await GünlükKaydetme(OlaySeviye.Ayıklama, "Select options:");
                //await GünlükKaydetme(OlaySeviye.Ayıklama, seçenekler.ToString());

                return seçenekler.ToString();
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
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
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsonStr,
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

        public static async Task<List<SelectListItem>> RestoranlarListeAl()
        {
            try
            {
                RestoranlarListe = new List<SelectListItem>();

                RestoranlarListe.Add(new SelectListItem() { Value = "0", Text = "(Restoran seçiniz)" });

                //This option helps system admins to add new restaurant admins easily and quickly
                RestoranlarListe.Add(new SelectListItem()
                { Value = "999999", Text = "-- Yeni bir restoran ekle, sadece isme göre --" });

                var rstrnlr = await RestoranlarAl();

                if (rstrnlr != null && rstrnlr.Any())
                    foreach (var rstrn in rstrnlr)
                        RestoranlarListe.Add(new SelectListItem() { Value = rstrn.Id.ToString(), Text = rstrn.İsim });

                return RestoranlarListe;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
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
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<Restoran>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<Restoran>(jsonStr,
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

        public static async Task<List<Restoran>> ŞimdikiKullanıcıRestoranlarAl()
        {
            string jsonStr = null;

            try
            {
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {klncId}");

                if (HazırlaWebYardımcı.Session != null && HazırlaWebYardımcı.Session.Keys.Contains($"KlncRstrnlr"))
                    jsonStr = HazırlaWebYardımcı.Session.GetString($"KlncRstrnlr");
                else
                {
                    using (var istemci = new System.Net.Http.HttpClient())
                    {
                        var klncId = GüvenlikYardımcı.ŞimdikiKullanıcıId;
                        jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/ŞimdikiKullanıcıRestoranlarAl/{klncId}/{0}");
                    }
                }

                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    if (HazırlaWebYardımcı.Session != null)
                        HazırlaWebYardımcı.Session.SetString($"KlncRstrnlr", jsonStr);

                    return System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<List<Restoran>> ŞimdikiKullanıcıRestoranlarAl(OnayDurum durum)
        {
            string jsonStr = null;

            try
            {
                //await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {klncId}");

                if (HazırlaWebYardımcı.Session != null && HazırlaWebYardımcı.Session.Keys.Contains($"KlncRstrnlr"))
                    jsonStr = HazırlaWebYardımcı.Session.GetString($"KlncRstrnlr");
                else
                {
                    using (var istemci = new System.Net.Http.HttpClient())
                    {
                        var klncId = GüvenlikYardımcı.ŞimdikiKullanıcıId;
                        jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/ŞimdikiKullanıcıRestoranlarAl/{klncId}/{durum}");
                    }
                }

                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    if (HazırlaWebYardımcı.Session != null)
                        HazırlaWebYardımcı.Session.SetString($"KlncRstrnlr", jsonStr);

                    return System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<List<SelectListItem>> ŞimdikiKullanıcıRestoranlarListe()
        {
            try
            {
                var klncId = GüvenlikYardımcı.ŞimdikiKullanıcıId;

                //await HazırlaWebYardımcı.AyıklamaKaydet($"Into... {klncId}");

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/ŞimdikiKullanıcıRestoranlarAl/{klncId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                    {
                        //await HazırlaWebYardımcı.AyıklamaKaydet($"Saving in cache...");

                        HazırlaWebYardımcı.MemCache.Set($"Klnc_{klncId}_Rstrnlr", jsonStr);

                        //await HazırlaWebYardımcı.AyıklamaKaydet($"Saving in session...");

                        //HazırlaWebYardımcı.Session.SetString($"Klnc_{klncId}_Rstrnlr", jsonStr);

                        //await HazırlaWebYardımcı.AyıklamaKaydet($"Deserializing...");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                        var rstrnlr = System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        if (rstrnlr != null && rstrnlr.Any())
                        {
                            RestoranlarListe = new List<SelectListItem>();

                            RestoranlarListe.Add(new SelectListItem() { Value = "0", Text = "(Restoran seçiniz)" });

                            foreach (var rstrn in rstrnlr)
                                RestoranlarListe.Add(new SelectListItem() { Value = rstrn.Id.ToString(), Text = rstrn.İsim });

                            return RestoranlarListe;
                        }
                        else
                            return null;
                    }
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

        public async Task<List<Restoran>> YeniRestoranlarAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/YeniRestoranlarAl");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Restoran>>(jsonStr,
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

        public static async Task RestoranGerekSinimlerYükle()
        {
            try
            {
                await Task.Run(() => { });
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniRestoranEkle(Restoran yeniRestoran)
        {
            try
            {
                yeniRestoran.SistemDurum = VarlıkSistemDurum.Aktif; yeniRestoran.ÖzelSektörMü = true;
                yeniRestoran.OluşturuKimsiId = Yardımcılar.GüvenlikYardımcı.ŞimdikiKullanıcıId; 
                yeniRestoran.Oluşturulduğunda = DateTime.Now;
                yeniRestoran.OnayDurum = OnayDurum.Beklemede;

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Saving restaurant...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON restaurant: " + JsonİçerikOluşturWithStr(yeniRestoran).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/YeniRestoranEkle", 
                        HazırlaWebYardımcı.JsonİçerikOluştur(yeniRestoran));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

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

        public static async Task<İcraSonuç> YeniRestoranEkleSadeceİsimGöre(string yeniRestoranİsim)
        {
            try
            {
                //await HazırlaWebYardımcı.AyıklamaKaydet("Saving restaurant by name only...");

                var yeniRestoran = new Restoran()
                {
                    İsim = yeniRestoranİsim,
                    SistemDurum = VarlıkSistemDurum.Atıl, //This new restaurant still needs other info
                    ÖzelSektörMü = true,
                    OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId,
                    Oluşturulduğunda = DateTime.Now,
                    OnayDurum = OnayDurum.Beklemede
                };

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Saving restaurant...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON restaurant: " + JsonİçerikOluşturWithStr(yeniRestoran).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/YeniRestoranEkle",
                        HazırlaWebYardımcı.JsonİçerikOluştur(yeniRestoran));

                    await HazırlaWebYardımcı.AyıklamaKaydet("Back from saving restaurant by name only");

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        return System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                        new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        //await GünlükKaydetme(OlaySeviye.Uyarı, "Back from saving restaurant. Null content");
                        await HazırlaWebYardımcı.AyıklamaKaydet("Something is wrong");

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

        public static async Task<İcraSonuç> RestoranHizmetlerDeğiştir(int restoranId, RestoranHizmetler hizmetler)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/HizmetlerDeğiştir",
                        HazırlaWebYardımcı.JsonİçerikOluştur(new List<string>() { restoranId.ToString(), hizmetler.ToString() }));

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

                throw ex;
            }
        }

        public async Task<İcraSonuç> RestoranOnayla(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/RestoranOnayla",
                                                            HazırlaWebYardımcı.JsonİçerikOluştur(restoranId));

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

        public async Task<İcraSonuç> RestoranReddet(int restoranId, string sebep)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/RestoranReddet",
                                    HazırlaWebYardımcı.JsonİçerikOluştur(new List<string>() { restoranId.ToString(), sebep }));

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

        public static async Task<İcraSonuç> RestoranDeğiştir(Restoran restoran)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PutAsync(RestoranlarUrl + "/RestoranDeğiştir", 
                        HazırlaWebYardımcı.JsonİçerikOluştur(restoran));

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

        public static async Task<List<VarlıkFotoğraf>> RestoranFotoğraflarAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant photos...");

                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/RestoranFotoğraflarAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<VarlıkFotoğraf>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<VarlıkFotoğraf>>(jsonStr,
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
