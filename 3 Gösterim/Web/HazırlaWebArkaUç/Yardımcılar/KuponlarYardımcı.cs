using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.Muhasebe;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazırlaWebArkaUç.Yardımcılar
{
    public class KuponlarYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        private static string KuponlarUrl => $"{HazırlaWebYardımcı.MaliHizmetUrl}/Kuponlar";
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<List<Kupon>> KuponlarAl()
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(KuponlarUrl + "/Kuponlar");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kupon>>(jsonStr);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Kupon>>(jsonStr,
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniKuponEkle(Kupon yeniKupon)
        {
            try
            {
                yeniKupon.SistemDurum = VarlıkSistemDurum.Aktif;
                yeniKupon.OluşturuKimsiId = GüvenlikYardımcı.ŞimdikiKullanıcıId; yeniKupon.Oluşturulduğunda = DateTime.Now;

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KuponlarUrl + "/YeniKuponEkle",
                        HazırlaWebYardımcı.JsonİçerikOluştur(yeniKupon));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        //var snç = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        var snç = System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        
                        //if (snç.BaşarılıMı)
                        //{
                        //    yeniKupon.Id = snç.YeniEklediId;
                        //    //Kullanıcılar.Add(yeniKullanıcı);
                        //}

                        return snç;
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

        public static async Task<İcraSonuç> KuponDeaktifEt(int kuponId)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KuponlarUrl + "/KuponDeaktifEt",
                        HazırlaWebYardımcı.JsonİçerikOluştur(kuponId));

                    if (msj.Content != null)
                    {
                        //var rslt = Newtonsoft.Json.JsonConvert.DeserializeObject<İcraSonuç>(await msj.Content.ReadAsStringAsync());
                        //var cntTp = msj.Content.Headers.ContentType.ToString();

                        //await GünlükKaydetme(OlaySeviye.Uyarı, $"Back from saving restaurant. Rslt: {cntTp} || {rslt}");

                        var snç = System.Text.Json.JsonSerializer.Deserialize<İcraSonuç>(await msj.Content.ReadAsStringAsync(),
                                        new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        //if (snç.BaşarılıMı)
                        //{
                        //    yeniKupon.Id = snç.YeniEklediId;
                        //    //Kullanıcılar.Add(yeniKullanıcı);
                        //}

                        return snç;
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
        #endregion
    }
}
