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
    public class GüvenlikVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<bool> AdSoyadZatenVarMı(string adSoyad)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Kullanıcılar.AnyAsync(k => k.AdSoyad.Equals(adSoyad));
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<bool> GirişİsimZatenKullanıldıMı(string girişİsim)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Kullanıcılar.AnyAsync(k => k.Girişİsim.Equals(girişİsim));
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<Kullanıcı> Giriş(string girişİsim)
        {
            try
            {
                //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Into -- {girişİsim} || {şifre}");

                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Kullanıcılar.FirstOrDefaultAsync(k => k.Girişİsim == girişİsim);

                    //var bulundu = klnc != null ? "Evet" : "Yok";
                    //await GünlükKaydetme(OlaySeviye.Ayıklama, $"Result: {bulundu}");

                    //if (klnc != null)
                    //{
                    //    if (string.Compare(klnc.Şifre, şifre, false) == 0)
                    //    {
                    //        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Logged in timestamp...");

                    //        klnc.SonGirişTarihVeZaman = DateTime.Now;
                    //        await vtBğlm.SaveChangesAsync();

                    //        //await GünlükKaydetme(OlaySeviye.Ayıklama, "Returning...");

                    //        return klnc;
                    //    }
                    //    else
                    //        return null;
                    //}
                    //else
                    //    return null;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniKullanıcıEkle(Kullanıcı yeniKullanıcı)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    await vtBğlm.Kullanıcılar.AddAsync(yeniKullanıcı);

                    await vtBğlm.SaveChangesAsync();

                    return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniKullanıcı.Id };
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> KullanıcıRestoranKaydet(int kullnıcıId, int restoranId)
        {
            try
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Ayıklama, "Into...");

                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    await vtBğlm.KullanıcılarRestoranlar.AddAsync(
                        new KullanıcıRestoran() { KullanıcıId = kullnıcıId, RestoranId = restoranId });

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> KullanıcıDegiştir(Kullanıcı kullanıcı)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var klnc = await vtBğlm.Kullanıcılar.FirstAsync(k => k.Id == kullanıcı.Id);

                    klnc.AktifMi = kullanıcı.AktifMi; klnc.Cinsiyet = kullanıcı.Cinsiyet;
                    klnc.Girişİsim = kullanıcı.Girişİsim; klnc.Pozisyon = kullanıcı.Pozisyon;
                    klnc.Rol = kullanıcı.Rol; klnc.KarmaŞifre = kullanıcı.KarmaŞifre;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> KullanıcıKaldır(int kullanıcıId, string sebep)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var klnc = await vtBğlm.Kullanıcılar.FirstAsync(k => k.Id == kullanıcıId);

                    klnc.SistemDurum = KullanıcıSistemDurum.Kaldırıldı; klnc.KaldırmaSebebi = sebep;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public static async Task<İcraSonuç> ŞifreDegiştir(int kullanıcıId, string karmaŞifre)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var klnc = await vtBğlm.Kullanıcılar.FirstAsync(k => k.Id == kullanıcıId);

                    klnc.KarmaŞifre = karmaŞifre;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
                }
            }
            catch (Exception ex)
            {
                await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}
