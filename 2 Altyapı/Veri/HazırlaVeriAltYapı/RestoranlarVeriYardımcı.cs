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
    public class RestoranlarVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        //public static async Task<List<Restoran>> RestoranlarAl(bool detaylarİle = false)
        //{
        //    try
        //    {
        //        using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
        //        {
        //            //var tümRstrn = vtBğlm.Restoranlar;
        //            var rstrnlrIds = vtBğlm.Restoranlar.Select(r => r.Id);

        //            if (rstrnlrIds != null && await rstrnlrIds.AnyAsync())
        //            {
        //                if (detaylarİle)
        //                {
        //                    var rstrnlr = new List<Restoran>(); //var rstrnlrIds = tümRstrn.Select(r => r.Id);

        //                    foreach (var rid in rstrnlrIds)
        //                        rstrnlr.Add(await DetaylıRestoranAl(rid));

        //                    return rstrnlr;
        //                }
        //                else
        //                {
        //                    return await vtBğlm.Restoranlar.ToListAsync();
        //                }
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

        public static async Task<List<Restoran>> RestoranlarAl(bool detaylarİle = false)
        {
            List<Restoran> rstrnlr = null;

            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var tümRstrn = vtBğlm.Restoranlar;
                    //var rstrnlrIds = vtBğlm.Restoranlar.Select(r => r.Id);
                    if (tümRstrn != null && await tümRstrn.AnyAsync())
                    {
                        rstrnlr = await tümRstrn.ToListAsync();

                        foreach (var r in rstrnlr)
                        {
                            var rstrnFoto = vtBğlm.Fotoğraflar.Where(f => f.VarlıkTip == FotoğrafVarlıkTip.Restoran && f.VarlıkId == r.Id);

                            if (rstrnFoto != null && await rstrnFoto.AnyAsync())
                                r.Fotoğraflar = await rstrnFoto.Select(f => f.Fotoğraf).ToListAsync();
                        }
                    }
                }
                
                if (rstrnlr != null && rstrnlr.Any())
                {
                    if (detaylarİle)
                        rstrnlr = await DetaylıRestoranlarAl(new List<Restoran>(rstrnlr));
                    else
                        rstrnlr = await MenülerOlanRestoranlarAl(new List<Restoran>(rstrnlr));
                }

                return rstrnlr;
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
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
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
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Restoranlar.FirstAsync(rst => rst.Id == id);
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Restoran>> DetaylıRestoranlarAl(List<Restoran> rstrnLst)
        {
            List<Restoran> detayRstrnlr = new List<Restoran>();

            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    foreach (var rstrn in rstrnLst)
                    {
                        var id = rstrn.Id;
                        var rstrnÇlşmZmn = vtBğlm.ÇalışmaZamanlamalar.Where(çz => çz.İşletmeId == id);
                        var rstrnMnu = vtBğlm.Menüler.Where(m => m.RestoranId == id);

                        if (rstrnÇlşmZmn != null && await rstrnÇlşmZmn.AnyAsync())
                            rstrn.ÇalışmaZamanlamalar = await rstrnÇlşmZmn.ToListAsync();

                        rstrn.İletişim = await vtBğlm.İşyeriİletişimler.FirstAsync(işyr => işyr.Id == rstrn.İletişimId);
                        rstrn.İletişim.Adres = await vtBğlm.YerlerAdresler.FirstAsync(ya => ya.Id == rstrn.İletişim.AdresId);
                        rstrn.İletişim.Adres.İl = rstrn.İletişim.Adres.İlId.HasValue ?
                                            await vtBğlm.İller.FirstAsync(il => il.Id == rstrn.İletişim.Adres.İlId.Value) : null;
                        rstrn.İletişim.Adres.İlçe = rstrn.İletişim.Adres.İlçeId.HasValue ?
                                            await vtBğlm.İlçeler.FirstAsync(ilç => ilç.Id == rstrn.İletişim.Adres.İlçeId.Value) : null;
                        rstrn.İletişim.Adres.Semt = rstrn.İletişim.Adres.SemtId.HasValue ?
                                            await vtBğlm.Semtler.FirstAsync(sm => sm.Id == rstrn.İletişim.Adres.SemtId.Value) : null;
                        rstrn.İletişim.Adres.Mahalle = rstrn.İletişim.Adres.MahalleId.HasValue ?
                                            await vtBğlm.Mahalleler.FirstAsync(mh => mh.Id == rstrn.İletişim.Adres.MahalleId.Value) : null;

                        if (rstrnMnu != null && await rstrnMnu.AnyAsync())
                        {
                            foreach (var mn in rstrnMnu)
                            {
                                var mnuOğlr = vtBğlm.MenülerÖğeler.Where(mo => mo.MenüId == mn.Id);

                                if (mnuOğlr != null && await mnuOğlr.AnyAsync())
                                {
                                    mn.MenüÖğeler = await mnuOğlr.ToListAsync();

                                    foreach (var mö in mn.MenüÖğeler)
                                    {
                                        var fot = await vtBğlm.Fotoğraflar.FirstOrDefaultAsync(
                                                f => f.VarlıkTip == FotoğrafVarlıkTip.MenüÖğe && f.VarlıkId == mö.Id);

                                        mö.Fotoğraf = fot != null ? fot.Fotoğraf : null;
                                    }
                                }

                                mn.Kategori = (await vtBğlm.Kategoriler.FirstAsync(k => k.Id == mn.KategoriId)).Ad;
                            }

                            rstrn.Menüler = await rstrnMnu.ToListAsync();
                        }

                        detayRstrnlr.Add(rstrn);
                    }
                }

                return detayRstrnlr;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        private static async Task<List<Restoran>> MenülerOlanRestoranlarAl(List<Restoran> rstrnLst)
        {
            List<Restoran> mnulrRstrnlr = new List<Restoran>();

            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    foreach (var rstrn in rstrnLst)
                    {
                        var id = rstrn.Id;
                        var rstrnMnu = vtBğlm.Menüler.Where(m => m.RestoranId == id);

                        if (rstrnMnu != null && await rstrnMnu.AnyAsync())
                            rstrn.Menüler = await rstrnMnu.ToListAsync();

                        mnulrRstrnlr.Add(rstrn);
                    }
                }

                return mnulrRstrnlr;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Restoran>> ŞimdikiKullanıcıRestoranlarAl(int kullanıcıId, string onayDurum)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var klncRstrnIdler = vtBğlm.KullanıcılarRestoranlar.Where(kr => kr.KullanıcıId == kullanıcıId);

                    if (klncRstrnIdler != null && await klncRstrnIdler.AnyAsync())
                    {
                        var rstrnIdler = await klncRstrnIdler.Select(kr => kr.RestoranId).ToListAsync();
                        IQueryable<Restoran> sorguSnç = null;

                        switch(onayDurum)
                        {
                            case "0": //Hepsi
                                sorguSnç = vtBğlm.Restoranlar.Where(rst => rstrnIdler.Contains(rst.Id));
                                break;
                            case "1": //Onay Beklemde
                                sorguSnç = vtBğlm.Restoranlar.Where(rst => rstrnIdler.Contains(rst.Id) &&
                                                rst.OnayDurum == OnayDurum.Beklemede);
                                break;
                            case "2": //Onaylı
                                sorguSnç = vtBğlm.Restoranlar.Where(rst => rstrnIdler.Contains(rst.Id) &&
                                                rst.OnayDurum == OnayDurum.Onaylı);
                                break;
                            //default:
                            //    sorguSnç = vtBğlm.Restoranlar.Where(rst => rstrnIdler.Contains(rst.Id));
                            //    break;
                        }

                        if (sorguSnç != null && await sorguSnç.AnyAsync())
                            return await sorguSnç.ToListAsync();
                        else
                            return null;
                    }
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

        public static async Task<List<Restoran>> YeniRestoranlarAl()
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrn = vtBğlm.Restoranlar.Where(rst => rst.OnayDurum == OnayDurum.Beklemede);

                    if (rstrn != null && await rstrn.AnyAsync())
                        return await rstrn.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> HizmetlerDeğiştir(int restoranId, RestoranHizmetler hizmetler)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrn = await vtBğlm.Restoranlar.FirstAsync(rst => rst.Id == restoranId);

                    rstrn.Hizmetler = hizmetler;

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

        public static async Task<İcraSonuç> RestoranOnayla(int restoranId)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrn = await vtBğlm.Restoranlar.FirstAsync(rst => rst.Id == restoranId);

                    rstrn.OnayDurum = OnayDurum.Onaylı;

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

        public static async Task<İcraSonuç> RestoranReddet(int restoranId, string sebep)
        {
            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var rstrn = await vtBğlm.Restoranlar.FirstAsync(rst => rst.Id == restoranId);

                    rstrn.OnayDurum = OnayDurum.Reddetti; rstrn.ReddetSebebi = sebep;

                    await vtBğlm.SaveChangesAsync();

                    return İcraSonuç.Başarılı;
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
                //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Into...");

                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
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

                        yeniRestoran.İletişimId = await HazırlaVeriYardımcı.İletişimKaydet(vtBğlm, yeniRestoran.İletişim);

                        //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Actual restaurant save...");

                        var rstEkledi = await vtBğlm.Restoranlar.AddAsync(yeniRestoran); await vtBğlm.SaveChangesAsync();

                        if (rstEkledi != null && rstEkledi.Entity.Id > 0)
                        {
                            //await HazırlaVeriYardımcı.GünlükKaydetme(new Günlük()
                            //{
                            //    Seviye = OlaySeviye.Uyarı,
                            //    Kaynak = "VeriYardımcı.İletişimKaydetme",
                            //    Mesaj = "Checking restaurant menus...",
                            //    Tarih = DateTime.Now.ToString("dd-MM-yyyy"),
                            //    Zaman = DateTime.Now.ToString("HH:mm:ss.fffff"),
                            //});

                            //await MenülerVeriYardımcı.MenülerKaydetme(vtBğlm, yeniRestoran.Id, yeniRestoran.Menüler);

                            var nPics = yeniRestoran.Fotoğraflar != null ? $"Found: {yeniRestoran.Fotoğraflar.Count} pics" : "No pics";

                            //await HazırlaVeriYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Checking restaurant photos ({nPics})");

                            if (yeniRestoran.ÇalışmaZamanlamalar != null && yeniRestoran.ÇalışmaZamanlamalar.Any())
                            {
                                foreach (var çlzmn in yeniRestoran.ÇalışmaZamanlamalar)
                                    vtBğlm.ÇalışmaZamanlamalar.Add(new ÇalışmaZamanlama()
                                    { 
                                        İşletmeId = yeniRestoran.Id, 
                                        HaftaGün = çlzmn.HaftaGün,
                                        Saatten = çlzmn.Saatten,
                                        Saate = çlzmn.Saate,
                                        SistemDurum = VarlıkSistemDurum.Aktif,
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
                                        SistemDurum = VarlıkSistemDurum.Aktif,
                                        OluşturuKimsiId = yeniRestoran.OluşturuKimsiId,
                                        Oluşturulduğunda = DateTime.Now
                                    });

                                await vtBğlm.SaveChangesAsync();
                            }

                            await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Uyarı, "Saved successsfully");

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
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var öncekiRstr = await vtBğlm.Restoranlar.FirstAsync(kf => kf.Id == restoran.Id);

                    //öncekiRstr.ÇalışmaSaatleri
                    öncekiRstr.SistemDurum = restoran.SistemDurum;

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
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    var mnulr = vtBğlm.Menüler.Where(m => m.RestoranId == restoranId);

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
        //        using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
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
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
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

        public static async Task<IEnumerable<Restoran>> ErzakAra(string aramaDizisi)
        {
            IEnumerable<Restoran> aramaSonucu = null;
            const int maksSonuçAdet = 10;

            try
            {
                using (var vtBğlm = new HazırlaVeriBağlam() { BağlantıDizesi = HazırlaVeriYardımcı.BağlantıDizesi })
                {
                    aramaSonucu = new List<Restoran>();

                    var rstrnslr = vtBğlm.Restoranlar.Where(r => r.İsim.Contains(aramaDizisi));

                    if (rstrnslr != null && await rstrnslr.AnyAsync())
                        (aramaSonucu as List<Restoran>).AddRange(await rstrnslr.Take(maksSonuçAdet).ToListAsync());

                    if (aramaSonucu != null && aramaSonucu.Count() < maksSonuçAdet)
                    {
                        var mnulr = vtBğlm.Menüler.Where(m => m.Ad.Contains(aramaDizisi));

                        if (mnulr != null && await mnulr.AnyAsync())
                        {
                            var rstrnIdlr = mnulr.Select(m => m.RestoranId).Distinct();

                            (aramaSonucu as List<Restoran>).AddRange(
                                await vtBğlm.Restoranlar.Where(r => rstrnIdlr.Any(rid => rid == r.Id)).Take(maksSonuçAdet).ToListAsync());
                        }
                    }

                    if (aramaSonucu != null && aramaSonucu.Count() < maksSonuçAdet)
                    {
                        var mnuÖğlr = vtBğlm.MenülerÖğeler.Where(mö => mö.Ad.Contains(aramaDizisi));

                        if (mnuÖğlr != null && await mnuÖğlr.AnyAsync())
                        {
                            var mnIdlr = await mnuÖğlr.Select(mö => mö.MenüId).Distinct().ToListAsync();
                            var mnulr = vtBğlm.Menüler.Where(m => mnIdlr.Any(mi => mi == m.Id));
                            var rstrnIdlr = mnulr.Select(m => m.RestoranId).Distinct();

                            (aramaSonucu as List<Restoran>).AddRange(
                                await vtBğlm.Restoranlar.Where(r => rstrnIdlr.Any(rid => rid == r.Id)).Take(maksSonuçAdet).ToListAsync());
                        }
                    }

                    if (aramaSonucu.Any())
                    {
                        aramaSonucu = aramaSonucu.Take(maksSonuçAdet);

                        foreach (var rstr in aramaSonucu)
                            rstr.Fotoğraflar = new List<byte[]>(){ (await vtBğlm.Fotoğraflar.FirstAsync(
                                    f => f.VarlıkTip == FotoğrafVarlıkTip.Restoran && f.VarlıkId == rstr.Id )).Fotoğraf };
                    }

                    return aramaSonucu;
                }
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.HayaKaydet(ex);
                throw ex;
            }
        }
        #endregion
    }
}
