using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaÇekirdek.Valıklar.Güvenlik;

namespace HazırlaVeriAltYapı
{
    public class MenülerVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<İcraSonuç> YeniMenüKategoriEkle(Kategori yeniKategori)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    
                    var katEkledi = await vtBğlm.Kategoriler.AddAsync(yeniKategori); await vtBğlm.SaveChangesAsync();

                    if (katEkledi != null && katEkledi.Entity.Id > 0)
                    {
                        if (yeniKategori.AltKategoriler != null && yeniKategori.AltKategoriler.Any())
                        {
                            foreach (var altKat in yeniKategori.AltKategoriler)
                            {
                                altKat.TemelKategoriId = yeniKategori.Id; await vtBğlm.Kategoriler.AddAsync(altKat);
                            }

                            await vtBğlm.SaveChangesAsync();
                        }

                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniKategori.Id };
                    }
                    else
                        return İcraSonuç.BaşarıSız;
                    
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Kategori>> RestoranMenüKategorilerAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var ktgrlr = vtBğlm.Kategoriler.Where(k => k.RestoranId == restoranId);

                    if (ktgrlr != null && await ktgrlr.AnyAsync())
                        return await ktgrlr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<Menü> MenüAl(int menüId)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Menüler.FirstAsync(m => m.Id == menüId);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Menü>> KategoriGöreMenülerAl(int kategoriId, int altKatrgoriId = 0)
        {
            try
            {
                IQueryable<Menü> mnulr = null;

                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    if (altKatrgoriId == 0)
                        mnulr = vtBğlm.Menüler.Where(m => m.KategoriId == kategoriId);
                    else
                        mnulr = vtBğlm.Menüler.Where(m => m.KategoriId == kategoriId && 
                                                m.AltKategoriId.HasValue && m.AltKategoriId.Value == altKatrgoriId);

                    if (mnulr != null && await mnulr.AnyAsync())
                        return await mnulr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniMenüEkle(Menü yeniMenü)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var aynaMnu = await vtBğlm.Menüler.FirstOrDefaultAsync(mn => 
                                                mn.RestoranId== yeniMenü.RestoranId
                                                && mn.Ad.Equals(yeniMenü.Ad, StringComparison.OrdinalIgnoreCase));

                    if (aynaMnu == null)
                    {
                        var mnEkledi = await vtBğlm.Menüler.AddAsync(yeniMenü); await vtBğlm.SaveChangesAsync();

                        if (mnEkledi != null && mnEkledi.Entity.Id > 0)
                        {
                            if (yeniMenü.MenüÖğeler != null && yeniMenü.MenüÖğeler.Any())
                            {
                                foreach (var mnuÖğ in yeniMenü.MenüÖğeler)
                                {
                                    mnuÖğ.MenüId = yeniMenü.Id; await vtBğlm.MenülerÖğeler.AddAsync(mnuÖğ);
                                }

                                await vtBğlm.SaveChangesAsync();
                            }

                            return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniMenü.Id };
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
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        //private static async Task GerçekleşenRestoranMenüleriGörünümüOluştur()
        //{
        //    try
        //    {
        //        using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
        //        {
        //            await vtBğlm.Database.ExecuteSqlRawAsync("");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
        //        throw ex;
        //    }
        //}

        public static async Task<List<Menü>> YeniMenülerAl()
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrnMnulr = vtBğlm.Menüler.Where(m => !m.Onaylandı
                                            && (m.ReddetSebebi == null || m.ReddetSebebi.Length == 0));

                    if (rstrnMnulr != null && await rstrnMnulr.AnyAsync())
                        return await rstrnMnulr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Menü>> RestoranYeniMenülerAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrnMnulr = vtBğlm.Menüler.Where(m => m.RestoranId == restoranId && !m.Onaylandı
                                        && (m.ReddetSebebi == null || m.ReddetSebebi.Length == 0));

                    if (rstrnMnulr != null && await rstrnMnulr.AnyAsync())
                        return await rstrnMnulr.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüOnayla(int menüId)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var mnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menüId);

                    mnu.Onaylandı = true;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüReddet(int menüId, string sebep)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var mnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menüId);

                    mnu.Onaylandı = false; mnu.ReddetSebebi = sebep;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüDeğiştir(Menü menü)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var öncekiMnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menü.Id);

                    öncekiMnu.SistemDurum = menü.SistemDurum;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task MenülerKaydetme(HazırlaVeriBağlam vtBğlm, int rstrnId, int klncId, List<Menü> menüler)
        {
            try
            {
                if (menüler != null && menüler.Any())
                {
                    foreach (var mn in menüler)
                    {
                        mn.RestoranId = rstrnId; mn.SistemDurum = VarlıkSistemDurum.Aktif;
                        mn.OluşturuKimsiId = klncId; mn.Oluşturulduğunda = DateTime.Now;

                        var mnEkldi = await vtBğlm.Menüler.AddAsync(mn);

                        if (mnEkldi != null && mnEkldi.Entity.Id > 0 && mn.MenüÖğeler != null && mn.MenüÖğeler.Any())
                            foreach (var mnuÖğ in mn.MenüÖğeler)
                            {
                                mnuÖğ.MenüId = mn.Id; mnuÖğ.SistemDurum = VarlıkSistemDurum.Aktif; 
                                mnuÖğ.Oluşturulduğunda = DateTime.Now;

                                await vtBğlm.MenülerÖğeler.AddAsync(mnuÖğ);
                            }
                    }

                    await vtBğlm.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        //public static async Task<List<MenüÖğe>> MenüÖğeleriniBul(string aramaDizisi)
        //{
        //    List<MenüÖğe> öğeler = null;

        //    try
        //    {
        //        using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
        //        {
        //            var bulduÖğeler = vtBğlm.MenülerÖğeler.Where(mö =>
        //                                        mö.Ad.Contains(aramaDizisi)
        //                                        || (!string.IsNullOrWhiteSpace(mö.Betimleme) && mö.Betimleme.Contains(aramaDizisi)));
        //        }

        //        return öğeler;
        //    }
        //    catch (Exception ex)
        //    {
        //        await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
        //        throw ex;
        //    }
        //}
        #endregion
    }
}
