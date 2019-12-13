using Microsoft.EntityFrameworkCore;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaÇekirdek.Valıklar.Güvenlik;

namespace HazırlaVeriAltYapı
{
    public class HazırlaVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        static HazırlaVeriYardımcı()
        {

        }
        #endregion

        #region Properties (Özellikler)
        public static string BağlantıDizesi { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<int> İletişimKaydet(HazırlaVeriBağlam vtBğlm, İşyeriİletişim iletişim)
        {
            try
            {
                //await GünlükKaydetme(new Günlük()
                //{
                //    Seviye = OlaySeviye.Uyarı,
                //    Kaynak = "VeriYardımcı.İletişimKaydetme",
                //    Mesaj = "Saving communication...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                if (iletişim != null)
                {
                    if (iletişim.Adres != null)
                    {
                        iletişim.Adres.SistemDurum = VarlıkSistemDurum.Aktif; iletişim.Adres.Oluşturulduğunda = DateTime.Now;

                        await vtBğlm.YerlerAdresler.AddAsync(iletişim.Adres); await vtBğlm.SaveChangesAsync();

                        iletişim.AdresId = iletişim.Adres.Id;
                    }

                    iletişim.SistemDurum = VarlıkSistemDurum.Aktif; iletişim.Oluşturulduğunda = DateTime.Now;

                    await vtBğlm.İşyeriİletişimler.AddAsync(iletişim); await vtBğlm.SaveChangesAsync();

                    return iletişim.Id;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw;
            }
        }
        
        public static async Task<İşyeriİletişim> İşyeriİletişimAl(int id)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = BağlantıDizesi })
                {
                    var iletişim = await vtBğlm.İşyeriİletişimler.FirstAsync(m => m.Id == id);

                    iletişim.Adres = await vtBğlm.YerlerAdresler.FirstAsync(ad => ad.Id == iletişim.AdresId);

                    //TODO: Get telephones and emails

                    return iletişim;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task SistemİşlemKaydet(Sistemİşlem işlem)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = BağlantıDizesi })
                {
                    await vtBğlm.Sistemİşlemler.AddAsync(işlem); await vtBğlm.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Günlük>> GünlüklerAl(byte sayısı)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = BağlantıDizesi })
                {
                    var sırasınaGlklr = vtBğlm.BilgiGünlük.OrderByDescending(g => g.Id);

                    if (sırasınaGlklr != null)
                    {
                        var günlükler = sırasınaGlklr.Take(sayısı);

                        if (günlükler != null && await günlükler.AnyAsync())
                            return await günlükler.ToListAsync();
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HayaKaydet(ex);
                throw ex;
            }
        }

        public static async Task GünlükKaydet(Günlük günlük)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = BağlantıDizesi })
                {
                    var newEntry = await vtBğlm.BilgiGünlük.AddAsync(günlük); await vtBğlm.SaveChangesAsync();

                    //if (newEntry != null)
                    //{
                    //    var newId = newEntry.Entity != null ? newEntry.Entity.Id : -1;
                    //    return $"{newEntry.State} | {newId}";
                    //}
                    //else
                    //    return "NULL";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task GünlükKaydet(OlaySeviye seviye, string mesaj)
        {
            try
            {
                var şimdi = DateTime.Now;
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                await GünlükKaydet(
                    new Günlük()
                    {
                        Seviye = seviye,
                        Kaynak = $"{methodContainer.FullName}.{method.Name}",
                        Mesaj = mesaj,
                        Tarih = şimdi.ToString("dd-MM-yyyy"),
                        Zaman = şimdi.ToString("HH:mm:ss.fffff")
                    });
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

                await GünlükKaydet(
                    new Günlük()
                    {
                        Seviye = seviye,
                        Kaynak = $"{methodContainer.FullName}.{method.Name}",
                        Mesaj = GetInnerExceptions(ex),
                        Tarih = şimdi.ToString("dd-MM-yyyy"),
                        Zaman = şimdi.ToString("HH:mm:ss.fffff")
                    });
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public static async Task AyıklamaKaydet(string mesaj)
        {
            try
            {
                var şimdi = DateTime.Now;
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                await GünlükKaydet(
                    new Günlük()
                    {
                        Seviye = OlaySeviye.Ayıklama,
                        Kaynak = $"{methodContainer.FullName}.{method.Name}",
                        Mesaj = mesaj,
                        Tarih = şimdi.ToString("dd-MM-yyyy"),
                        Zaman = şimdi.ToString("HH:mm:ss.fffff")
                    });
            }
            catch
            {
            }
        }

        public static async Task HayaKaydet(Exception ex)
        {
            try
            {
                var şimdi = DateTime.Now;
                var method = new System.Diagnostics.StackFrame(4).GetMethod(); var methodContainer = method.DeclaringType;

                await GünlükKaydet(
                    new Günlük()
                    {
                        Seviye = OlaySeviye.Hata,
                        Kaynak = $"{methodContainer.FullName}.{method.Name}",
                        Mesaj = GetInnerExceptions(ex),
                        Tarih = şimdi.ToString("dd-MM-yyyy"),
                        Zaman = şimdi.ToString("HH:mm:ss.fffff")
                    });
            }
            catch
            {
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
