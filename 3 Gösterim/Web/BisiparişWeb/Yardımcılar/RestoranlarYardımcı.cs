using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiparişWeb.Yardımcılar
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
        private static string RestoranlarUrl => $"{BisiparişWebYardımcı.ArkaUçHizmetUrl}/Restoranlar";
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
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Preparing rest. services...");

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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<string> RestoranMutfaktlarSeçeneklerHazırla()
        {
            StringBuilder seçenekler = new StringBuilder();

            try
            {
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Preparing rest. services...");

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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<SelectListItem>> RestoranlarListeAl()
        {
            try
            {
                var rstrnlr = await RestoranlarAl();

                if (rstrnlr != null && rstrnlr.Any())
                {
                    RestoranlarListe = new List<SelectListItem>();

                    foreach (var rstrn in rstrnlr)
                        RestoranlarListe.Add(new SelectListItem() { Value = rstrn.Id.ToString(), Text = rstrn.İsim });
                }

                return RestoranlarListe;
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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restoran>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniRestoranEkle(Restoran yeniRestoran)
        {
            try
            {
                yeniRestoran.AktifMi = true; yeniRestoran.ÖzelSektörMü = true;
                yeniRestoran.OluşturuKimsiId = Yardımcılar.GüvenlikYardımcı.ŞimdikiKullanıcıId; 
                yeniRestoran.Oluşturulduğunda = DateTime.Now;
                yeniRestoran.OnayDurum = OnayDurum.Beklemede;

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Saving restaurant...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON restaurant: " + JsonİçerikOluşturWithStr(yeniRestoran).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(RestoranlarUrl + "/YeniRestoranEkle", 
                        BisiparişWebYardımcı.JsonİçerikOluştur(yeniRestoran));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                                                            BisiparişWebYardımcı.JsonİçerikOluştur(restoranId));

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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                                    BisiparişWebYardımcı.JsonİçerikOluştur(new Tuple<int, string>(restoranId, sebep)));

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
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
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
                        BisiparişWebYardımcı.JsonİçerikOluştur(restoran));

                    if (msj.Content != null)
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<VarlıkFotoğraf>> RestoranFotoğraflarAl(int restoranId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant photos...");

                    var jsonStr = await istemci.GetStringAsync(RestoranlarUrl + $"/RestoranFotoğraflarAl/{restoranId}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<VarlıkFotoğraf>>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        #endregion
    }
}
