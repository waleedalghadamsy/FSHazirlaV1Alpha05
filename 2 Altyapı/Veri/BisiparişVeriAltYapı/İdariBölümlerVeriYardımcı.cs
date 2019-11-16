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
    public class İdariBölümlerVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<List<Ülke>> ÜlkelerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var ülkeler = vtBğlm.Ülkeler;

                    if (ülkeler != null && await ülkeler.AnyAsync())
                        return await ülkeler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İl>> İllerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var iller = vtBğlm.İller;

                    if (iller != null && await iller.AnyAsync())
                        return await iller.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İl>> İlçelerOlanİllerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var iller = vtBğlm.İller;

                    if (iller != null && await iller.AnyAsync())
                    {
                        foreach (var il in iller)
                            il.İlçeler = await SemtlerOlanİlİlçelerAl(il.Id);

                        return await iller.ToListAsync();
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İl> İlAl(int id)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.İller.FirstAsync(il => il.Id == id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İlçe>> İlçelerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtİlçeler = vtBğlm.İlçeler;

                    if (vtİlçeler != null && await vtİlçeler.AnyAsync())
                        return await vtİlçeler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İlçe>> İlİlçelerAl(int ilId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var il = await vtBğlm.İller.FirstAsync(birİl => birİl.Id == ilId);
                    var vtİlİlçeler = vtBğlm.İlçeler.Where(ilç => ilç.İlId == il.Id);

                    if (vtİlİlçeler != null && await vtİlİlçeler.AnyAsync())
                        return await vtİlİlçeler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<İlçe>> SemtlerOlanİlİlçelerAl(int ilId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var il = await vtBğlm.İller.FirstAsync(birİl => birİl.Id == ilId);
                    var vtİlİlçeler = vtBğlm.İlçeler.Where(ilç => ilç.İlId == il.Id);

                    if (vtİlİlçeler != null && await vtİlİlçeler.AnyAsync())
                    {
                        foreach (var ilçe in vtİlİlçeler)
                            ilçe.Semtler = await MahallelerOlanİlçeSemtlerAl(ilçe.Id);

                        return await vtİlİlçeler.ToListAsync();
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İlçe> İlçeAl(int id)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.İlçeler.FirstAsync(ilç => ilç.Id == id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Semt>> SemtlerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtSemtler = vtBğlm.Semtler;

                    if (vtSemtler != null && await vtSemtler.AnyAsync())
                        return await vtSemtler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Semt>> İlçeSemtlerAl(int ilçeId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtİlçSemtler = vtBğlm.Semtler.Where(smt => smt.İlçeId == ilçeId);

                    if (vtİlçSemtler != null && await vtİlçSemtler.AnyAsync())
                        return await vtİlçSemtler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Semt>> MahallelerOlanİlçeSemtlerAl(int ilçeId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtİlçSemtler = vtBğlm.Semtler.Where(smt => smt.İlçeId == ilçeId);

                    if (vtİlçSemtler != null && await vtİlçSemtler.AnyAsync())
                    {
                        foreach (var semt in vtİlçSemtler)
                            semt.Mahalleler = await SemtMahallelerAl(semt.Id);

                        return await vtİlçSemtler.ToListAsync();
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<Semt> SemtAl(int id)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Semtler.FirstAsync(smt => smt.Id == id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Mahalle>> MahallelerAl()
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtMahalleler = vtBğlm.Mahalleler;

                    if (vtMahalleler != null && await vtMahalleler.AnyAsync())
                        return await vtMahalleler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Mahalle>> SemtMahallelerAl(int semtId)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var vtMahSemtler = vtBğlm.Mahalleler.Where(mh => mh.SemtId == semtId);

                    if (vtMahSemtler != null && await vtMahSemtler.AnyAsync())
                        return await vtMahSemtler.ToListAsync();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<Mahalle> MahalleAl(int id)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    return await vtBğlm.Mahalleler.FirstAsync(mh => mh.Id == id);
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
