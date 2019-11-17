using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Muhasebe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BisiparişVeriAltYapı
{
    public class MaliVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<İcraSonuç> YeniKuponEkle(Kupon yeniKupon)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var kpnEklendi = await vtBğlm.Kuponlar.AddAsync(yeniKupon); await vtBğlm.SaveChangesAsync();

                    await vtBğlm.SaveChangesAsync();

                    if (kpnEklendi != null && kpnEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniKupon.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniPromosyonEkle(Promosyon yeniPromosyon)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var prsnEklendi = await vtBğlm.Promosyonlar.AddAsync(yeniPromosyon); await vtBğlm.SaveChangesAsync();

                    await vtBğlm.SaveChangesAsync();

                    if (prsnEklendi != null && prsnEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniPromosyon.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniSepetEkle(Sepet yeniSepet)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var istkEklendi = await vtBğlm.Sepetler.AddAsync(yeniSepet); await vtBğlm.SaveChangesAsync();

                    foreach (var sptÖğe in yeniSepet.Öğeler)
                    {
                        sptÖğe.AktifMi = true; sptÖğe.Oluşturulduğunda = DateTime.Now;
                        await vtBğlm.SepetlerÖğeler.AddAsync(sptÖğe);
                    }

                    await vtBğlm.SaveChangesAsync();

                    if (istkEklendi != null && istkEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniSepet.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<Sepet> MüşterşiSepetAl(int müşterşiId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Sepetler.FirstOrDefaultAsync(sp => sp.MüşteriId == müşterşiId);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SepetİptalEt(int sepetId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    vtBğlm.Sepetler.Remove(await vtBğlm.Sepetler.FirstAsync(sp => sp.Id == sepetId));

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniSiparişEkle(Sipariş yeniSipariş)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var istkEklendi = await vtBğlm.Siparişler.AddAsync(yeniSipariş); await vtBğlm.SaveChangesAsync();

                    if (istkEklendi != null && istkEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniSipariş.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Sipariş>> RestoranYeniSiparişlerAl(int restoranId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprşler = vtBğlm.Siparişler.Where(
                                            sp => sp.RestoranId == restoranId && sp.Durum == SiparişDurum.SiparişEdildi);

                    if (sprşler != null && await sprşler.AnyAsync())
                        return await sprşler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Sipariş>> RestoranBeklemeSiparişlerAl(int restoranId)
        {
            try
            {
                using(var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprşler = vtBğlm.Siparişler.Where(
                                            sp => sp.RestoranId == restoranId && sp.Durum == SiparişDurum.ServisEdilmeli);

                    if (sprşler != null && await sprşler.AnyAsync())
                        return await sprşler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<SiparişDurum> SiparişDurumAl(int siparişId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    return sprş.Durum;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SiparişOnayla(int siparişId)
        {
            try
            {
                using(var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    sprş.Durum = SiparişDurum.ServisEdilmeli;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SiparişİptalEt(int siparişId, string sebep)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    sprş.Durum = SiparişDurum.İptalEdildi; sprş.İptalSebebi = sebep;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SiparişHazırla(int siparişId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    sprş.Durum = SiparişDurum.Hazırlanıyor;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SiparişYapıldı(int siparişId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    sprş.Durum = SiparişDurum.Hazır;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> SiparişTeslimEdildi(int siparişId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var sprş = await vtBğlm.Siparişler.FirstAsync(sp => sp.Id == siparişId);

                    sprş.Durum = SiparişDurum.Teslimdi;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
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
