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
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    
                    var katEkledi = await vtBğlm.Kategoriler.AddAsync(yeniKategori); await vtBğlm.SaveChangesAsync();

                    if (katEkledi != null && katEkledi.Entity.Id > 0)
                    {
                        foreach (var altKat in yeniKategori.AltKategoriler)
                        {
                            altKat.TemelKategoriId = yeniKategori.Id; await vtBğlm.Kategoriler.AddAsync(altKat);
                        }

                        await vtBğlm.SaveChangesAsync();

                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniKategori.Id };
                    }
                    else
                        return İcraSonuç.BaşarıSız;
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Kategori>> RestoranMenüKategorilerAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
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
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<Menü> MenüAl(int menüId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Menüler.FirstAsync(m => m.Id == menüId);
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
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
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
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Menü>> YeniMenülerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
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
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Menü>> RestoranYeniMenülerAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
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
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüOnayla(int menüId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var mnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menüId);

                    //öncekiRstr.ÇalışmaSaatleri
                    mnu.Onaylandı = true;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüReddet(int menüId, string sebep)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var mnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menüId);

                    mnu.Onaylandı = false; mnu.ReddetSebebi = sebep;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> MenüDeğiştir(Menü menü)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var öncekiMnu = await vtBğlm.Menüler.FirstAsync(mn => mn.Id == menü.Id);

                    //öncekiRstr.ÇalışmaSaatleri
                    öncekiMnu.SistemDurum = menü.SistemDurum;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task MenülerKaydetme(BisiparişVeriBağlam vtBğlm, int yerId, List<Menü> menüler)
        {
            try
            {
                if (menüler != null && menüler.Any())
                {
                    foreach (var mn in menüler)
                    {
                        mn.RestoranId = yerId; mn.SistemDurum = VarlıkSistemDurum.Aktif; mn.Oluşturulduğunda = DateTime.Now;

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
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        #endregion
    }
}
