using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BisiparişÇekirdek.Valıklar.Esansiyel;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using BisiparişÇekirdek.Valıklar.Güvenlik;

namespace BisiparişVeriAltYapı
{
    public class RestoranlarVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<List<Restoran>> RestoranlarAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var tümRstrn = vtBğlm.Restoranlar;

                    if (tümRstrn != null && await tümRstrn.AnyAsync())
                        return await tümRstrn.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Restoran>> MahalleRestoranlarAl(int mahalleId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sorgu = from rst in vtBğlm.Restoranlar
                                from ilt in vtBğlm.İşyeriİletişimler
                                from ydr in vtBğlm.YerlerAdresler
                                where rst.İletişimId == ilt.Id && ilt.AdresId == ydr.Id && ydr.MahalleId == mahalleId
                                select rst;

                    if (sorgu != null && await sorgu.AnyAsync())
                        return await sorgu.ToListAsync();
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
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Restoranlar.FirstAsync(rst => rst.Id == id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniRestoranEkle(Restoran yeniRestoran)
        {
            try
            {
                //await GünlükKaydetme(new Günlük()
                //{
                //    Seviye = OlaySeviye.Uyarı,
                //    Kaynak = "VeriYardımcı.YeniRestoranEkle",
                //    Mesaj = "Into...",
                //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                //});

                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    //await GünlükKaydetme(new Günlük()
                    //{
                    //    Seviye = OlaySeviye.Uyarı,
                    //    Kaynak = "VeriYardımcı.YeniRestoranEkle",
                    //    Mesaj = "Checking...",
                    //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                    //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                    //});

                    var aynaRstrn = await vtBğlm.Restoranlar.FirstOrDefaultAsync(
                                            rst => rst.İsim.Equals(yeniRestoran.İsim, StringComparison.OrdinalIgnoreCase));

                    if (aynaRstrn == null)
                    {
                        //await GünlükKaydetme(new Günlük()
                        //{
                        //    Seviye = OlaySeviye.Uyarı,
                        //    Kaynak = "VeriYardımcı.YeniRestoranEkle",
                        //    Mesaj = "Restaurant name is new",
                        //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                        //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                        //});

                        yeniRestoran.İletişimId = await BisiparişVeriYardımcı.İletişimKaydetme(vtBğlm, yeniRestoran.İletişim);

                        //await GünlükKaydetme(new Günlük()
                        //{
                        //    Seviye = OlaySeviye.Uyarı,
                        //    Kaynak = "VeriYardımcı.İletişimKaydetme",
                        //    Mesaj = "Actual restaurant save...",
                        //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                        //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                        //});

                        var rstEkledi = await vtBğlm.Restoranlar.AddAsync(yeniRestoran); await vtBğlm.SaveChangesAsync();

                        if (rstEkledi != null && rstEkledi.Entity.Id > 0)
                        {
                            //await GünlükKaydetme(new Günlük()
                            //{
                            //    Seviye = OlaySeviye.Uyarı,
                            //    Kaynak = "VeriYardımcı.İletişimKaydetme",
                            //    Mesaj = "Checking restaurant menus...",
                            //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                            //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                            //});

                            await MenülerVeriYardımcı.MenülerKaydetme(vtBğlm, yeniRestoran.Id, yeniRestoran.Menüler);

                            //var nPics = yeniRestoran.Fotoğraflar != null ? $"Found: {yeniRestoran.Fotoğraflar.Count} pics" : "No pics";

                            //await GünlükKaydetme(new Günlük()
                            //{
                            //    Seviye = OlaySeviye.Uyarı,
                            //    Kaynak = "VeriYardımcı.İletişimKaydetme",
                            //    Mesaj = $"Checking restaurant photos ({nPics})",
                            //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                            //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                            //});

                            if (yeniRestoran.ÇalışmaZamanlamalar != null && yeniRestoran.ÇalışmaZamanlamalar.Any())
                            {
                                foreach (var çlzmn in yeniRestoran.ÇalışmaZamanlamalar)
                                    vtBğlm.ÇalışmaZamanlamalar.Add(new ÇalışmaZamanlama()
                                    { 
                                        İşletmeId = yeniRestoran.Id, 
                                        HaftaGün = çlzmn.HaftaGün,
                                        Saatten = çlzmn.Saatten,
                                        Saate = çlzmn.Saate,
                                        AktifMi = true,
                                        OluşturuKimsiId = yeniRestoran.OluşturuKimsiId,
                                        Oluşturulduğunda = DateTime.Now
                                    });

                                await vtBğlm.SaveChangesAsync();
                            }

                            if (yeniRestoran.Fotoğraflar != null && yeniRestoran.Fotoğraflar.Any())
                            {
                                foreach (var ftf in yeniRestoran.Fotoğraflar)
                                    vtBğlm.Fotoğraflar.Add(new VarlıkFotoğraf()
                                    { 
                                        VarlıkId = yeniRestoran.Id, 
                                        VarlıkTip = FotoğrafVarlıkTip.Restoran, 
                                        Fotoğraf = ftf,
                                        AktifMi = true,
                                        OluşturuKimsiId = yeniRestoran.OluşturuKimsiId,
                                        Oluşturulduğunda = DateTime.Now
                                    });

                                await vtBğlm.SaveChangesAsync();
                            }

                            //await GünlükKaydetme(new Günlük()
                            //{
                            //    Seviye = OlaySeviye.Uyarı,
                            //    Kaynak = "VeriYardımcı.YeniRestoranEkle",
                            //    Mesaj = "Saved successsfully",
                            //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                            //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                            //});

                            return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniRestoran.Id };
                        }
                        else
                            return İcraSonuç.BaşarıSız;
                    }
                    else
                        return new İcraSonuç() { BaşarılıMı = false, Mesaj = "Bu restoran zaten var." };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> RestoranDeğiştir(Restoran restoran)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var öncekiRstr = await vtBğlm.Restoranlar.FirstAsync(kf => kf.Id == restoran.Id);

                    //öncekiRstr.ÇalışmaSaatleri
                    öncekiRstr.AktifMi = restoran.AktifMi;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
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
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var mnulr = vtBğlm.Menüler.Where(m => m.YerTür == YerTür.Restoran && m.YerId == restoranId);

                    if (mnulr != null && await mnulr.AnyAsync())
                        return await mnulr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public static async Task<İşyeriİletişim> RestoranİletişimAl(int iletişimId)
        //{
        //    try
        //    {
        //        using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
        //        {
        //            var rstİletişim = await vtBğlm.İşyeriİletişimler.FirstOrDefaultAsync(m => m.Id == iletişimId);

        //            if (rstİletişim != null)
        //            {
        //                rstİletişim.Adres = await vtBğlm.YerlerAdresler.FirstAsync(ya => ya.Id == rstİletişim.AdresId);

        //                //TODO: Get telephones and emails

        //                return rstİletişim;
        //            }
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static async Task<List<VarlıkFotoğraf>> RestoranFotoğraflarAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var fotolr = vtBğlm.Fotoğraflar.Where(m => m.VarlıkTip == FotoğrafVarlıkTip.Restoran && m.VarlıkId == restoranId);

                    if (fotolr != null && await fotolr.AnyAsync())
                        return await fotolr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
