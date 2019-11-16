using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BisiparişWeb.Yardımcılar
{
    public class GüvenlikYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public static string GüvenlikHizmetUrl { get; set; }
        private static string KullanıcılarUrl => $"{GüvenlikHizmetUrl}/Kullanıcılar";
        public static bool KullanıcıGirişYaptıMı
        {
            get
            {
                return BisiparişWebYardımcı.Session.Keys.Contains("GirişYaptıMı") ? BisiparişWebYardımcı.Session.GetString("GirişYaptıMı").Equals("Evet") : false;
            }
            set
            {
                if (value)
                    BisiparişWebYardımcı.Session.SetString("GirişYaptıMı", "Evet");
                else
                    BisiparişWebYardımcı.Session.SetString("GirişYaptıMı", "Hayır");
            }
        }
        public static Kullanıcı ŞuAnkiKullanıcı
        {
            get
            {
                try
                {
                    //Task.Run(async () => await GünlükKaydetme(OlaySeviye.Ayıklama, "Retrieveing user from session"));

                    var jsonKlnc = BisiparişWebYardımcı.Session.Keys.Contains("ŞuAnkiKullanıcı") ? BisiparişWebYardımcı.Session.GetString("ŞuAnkiKullanıcı") : null;

                    //Task.Run(async () => await GünlükKaydetme(OlaySeviye.Ayıklama,
                    //        !string.IsNullOrWhiteSpace(jsonKlnc) ? jsonKlnc : "(Nothing)"));

                    return
                        !string.IsNullOrWhiteSpace(jsonKlnc) ? Newtonsoft.Json.JsonConvert.DeserializeObject<Kullanıcı>(jsonKlnc) : null;
                }
                catch (Exception ex)
                {
                    Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));

                    return null;
                }
            }
            set
            {
                try
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into Session User Set");

                            var jsnUser = Newtonsoft.Json.JsonConvert.SerializeObject(value);

                            //await GünlükKaydetme(OlaySeviye.Ayıklama, $"JSON User: {jsnUser}");

                            BisiparişWebYardımcı.Session.SetString("ŞuAnkiKullanıcı", jsnUser);

                            //await GünlükKaydetme(OlaySeviye.Ayıklama, "The user object is stored in session");

                            //var usrKey = Session.Keys.Contains("ŞuAnkiKullanıcı");

                            //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Is the user really in session: {usrKey}");

                            //var ssnUsr = Session.GetString("ŞuAnkiKullanıcı");

                            //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Verifying user from session: {ssnUsr}");
                        }
                        catch (Exception ex)
                        {
                            await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                        }
                    });
                }
                catch (Exception ex)
                {
                    Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
                }
            }
        }
        public static int ŞuAnkiKullanıcıId
        {
            get
            {
                return BisiparişWebYardımcı.Session.Keys.Contains("KullanıcıId") ? BisiparişWebYardımcı.Session.GetInt32("KullanıcıId").Value : -1;
            }
            set
            {
                BisiparişWebYardımcı.Session.SetInt32("KullanıcıId", value);
            }
        }
        public static string ŞuAnkiKullanıcıİsim
        {
            get
            {
                try
                {
                    var isSessionAvailable = BisiparişWebYardımcı.Session != null ? "OK" : "(NULL)";

                    //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Into..."));
                    //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama,
                    //    $"Session obj: {isSessionAvailable}"));

                    return BisiparişWebYardımcı.Session.Keys.Contains("Kullanıcıİsim") ? BisiparişWebYardımcı.Session.GetString("Kullanıcıİsim") : "(Hiç kimse)";
                }
                catch (Exception ex)
                {
                    Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
                    return "(ERROR!)";
                }
            }
            set
            {
                try
                {
                    //Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Setting user name..."));
                    BisiparişWebYardımcı.Session.SetString("Kullanıcıİsim", value);
                }
                catch (Exception ex)
                {
                    Task.Run(async () => await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message));
                }
            }
        }
        public static bool ŞuAnkiKullanıcıSistemYöneticiMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.SistemYönetici;
        public static bool ŞuAnkiKullanıcıİşletmeYöneticiMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeYönetici;
        public static bool ŞuAnkiKullanıcıDestekTemsilciMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.MüşteriDestekTemsilci;
        public static bool ŞuAnkiKullanıcıİşletmeKullanıcıMı => ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeKullanıcı;
        public static bool ŞuAnkiKullanıcıMüşteriMi => ŞuAnkiKullanıcı.Rol == KullanıcıRol.Müşteri;
        public static string ŞuAnkiKullanıcıMenüKısmiGörüntü { get; set; }
        public static List<SelectListItem> KullanıcıRolar { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task KullanıcıRolarHazırla()
        {
            try
            {
                //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                await Task.Run(async () =>
                {
                    //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                    if (ŞuAnkiKullanıcı != null)
                    {
                        if (ŞuAnkiKullanıcı.Rol == KullanıcıRol.SistemYönetici)
                        {
                            KullanıcıRolar = new List<SelectListItem>()
                                {
                                    new SelectListItem() { Value = "0", Text = "(Rol seçiniz)", Selected = true },
                                    new SelectListItem() { Value = "1", Text = "Sistem Yönetici" },
                                    new SelectListItem() { Value = "2", Text = "Müşteri Destek Temsilci" },
                                    new SelectListItem() { Value = "3", Text = "İşletme Yönetici" },
                                    new SelectListItem() { Value = "4", Text = "İşletme Çalışan" }
                                };
                        }
                        else if (ŞuAnkiKullanıcı.Rol == KullanıcıRol.İşletmeYönetici)
                        {
                            KullanıcıRolar = new List<SelectListItem>()
                                {
                                    new SelectListItem() { Value = "0", Text = "(Rol seçiniz)", Selected = true },
                                    new SelectListItem() { Value = "3", Text = "İşletme Yönetici" },
                                    new SelectListItem() { Value = "4", Text = "İşletme Çalışan" }
                                };
                        }
                    }
                    else
                        await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "User is null!!!");
                });
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<Kullanıcı> Giriş(string girişİsim, string şifre)
        {
            try
            {
                //await GünlükKaydetme(OlaySeviye.Ayıklama, "Into...");

                var k = new Kullanıcı() { Id = 5, Girişİsim = girişİsim, Rol = KullanıcıRol.İşletmeKullanıcı, AdSoyad = "Ameen" };

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    //Hem giriş isim hem de şifre tek bir nesne olarak gönderme
                    var girişİsimVeŞifre = $"{girişİsim} <||> {şifre}";

                    var jsonStr = await istemci.GetStringAsync(KullanıcılarUrl + $"/Giriş/{girişİsimVeŞifre}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Kullanıcı>(jsonStr);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task KullanıcıGirişti(Kullanıcı kullanıcı)
        {
            try
            {
                ŞuAnkiKullanıcı = kullanıcı; ŞuAnkiKullanıcıId = kullanıcı.Id; ŞuAnkiKullanıcıİsim = kullanıcı.AdSoyad;
                KullanıcıGirişYaptıMı = true;

                await KullanıcıRolarHazırla();
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<bool> GirişİsimZatenKullanıldıMı(string girişİsim)
        {
            try
            {
                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var jsonStr = await istemci.GetStringAsync(KullanıcılarUrl + $"/GirişİsimZatenKullanıldıMı/{girişİsim}");

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(jsonStr);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public static async Task Çıkış()
        //{
        //    try
        //    {
        //        Session.Clear();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static async Task<İcraSonuç> YeniKullanıcıEkle(Kullanıcı yeniKullanıcı)
        {
            try
            {
                yeniKullanıcı.AktifMi = true;
                yeniKullanıcı.OluşturuKimsiId = ŞuAnkiKullanıcıId; yeniKullanıcı.Oluşturulduğunda = DateTime.Now;

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Saving user...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KullanıcılarUrl + "/YeniKullanıcıEkle", 
                        BisiparişWebYardımcı.JsonİçerikOluştur(yeniKullanıcı));

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
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> KullanıcıDegiştir(Kullanıcı kullanıcı)
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Modifying user...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KullanıcılarUrl + "/KullanıcıDegiştir", 
                        BisiparişWebYardımcı.JsonİçerikOluştur(kullanıcı));

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
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> ŞifreDegiştir(Kullanıcı kullanıcı, string şifre)
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Changing password...");
                //await GünlükKaydetme(OlaySeviye.Uyarı, "JSON user: " + JsonİçerikOluşturWithStr(yeniKullanıcı).Item2);

                kullanıcı.Şifre = şifre;

                using (var istemci = new System.Net.Http.HttpClient())
                {
                    var msj = await istemci.PostAsync(KullanıcılarUrl + "/ŞifreDegiştir",
                        BisiparişWebYardımcı.JsonİçerikOluştur(kullanıcı));

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
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}
