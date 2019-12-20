using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaVeriAltYapı;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖnUçİşlemlerHizmet.Yardımcılar
{
    public class ÖnUçHizmetYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public static IMemoryCache MemCache { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static void Hazırlama(IMemoryCache cache)
        {
            try
            {
                Task.Run(async () => { MemCache = cache; await RestoranlarAl(); });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task RestoranlarAl()
        {
            try
            {
                MemCache.Set("Restoranlar", await RestoranlarVeriYardımcı.RestoranlarAl(true));
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<Restoran> RestoranAl(int id)
        {
            try
            {
                var rstrnlr = MemCache.Get<List<Restoran>>("Restoranlar");

                return rstrnlr.First(r => r.Id == id);
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }

        public static async Task<List<Restoran>> ErzakAra(string aramaDizisi)
        {
            IEnumerable<Restoran> aramaSonucu = null;
            const int maksSonuçAdet = 10;

            try
            {
                var tümRstrnlar = MemCache.Get<List<Restoran>>("Restoranlar");

                aramaSonucu = new List<Restoran>();

                var rstrnlr = tümRstrnlar.Where(r => r.İsim.Contains(aramaDizisi));

                if (rstrnlr != null && rstrnlr.Any())
                    (aramaSonucu as List<Restoran>).AddRange(rstrnlr.Take(maksSonuçAdet).ToList());

                if (aramaSonucu.Count() < maksSonuçAdet)
                    (aramaSonucu as List<Restoran>).AddRange(
                        tümRstrnlar.Where(r => r.Menüler.Any(m => m.Ad.Contains(aramaDizisi))).Take(maksSonuçAdet));

                if (aramaSonucu.Count() < maksSonuçAdet)
                    (aramaSonucu as List<Restoran>).AddRange(tümRstrnlar.Where(r => r.Menüler.Any(m => 
                                            m.MenüÖğeler.Any(mö => mö.Ad.Contains(aramaDizisi)))).Take(maksSonuçAdet));

                return aramaSonucu.Any() ? aramaSonucu.Take(maksSonuçAdet).ToList() : null;
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.HayaKaydet(ex);
                throw ex;
            }
        }

        public static List<Restoran> BölgedeRestoranlarAl(int ilId, int ilçeId, int semtId)
        {
            IEnumerable<Restoran> aramaSonucu = null;
            const int maksSonuçAdet = 10;

            try
            {
                var tümRstrnlar = MemCache.Get<List<Restoran>>("Restoranlar");

                aramaSonucu = new List<Restoran>();

                if (semtId > 0)
                {
                    var semtRstrnlr = tümRstrnlar.Where(r => r.İletişim.Adres.SemtId == semtId);

                    if (semtRstrnlr != null && semtRstrnlr.Any())
                        (aramaSonucu as List<Restoran>).AddRange(semtRstrnlr.Take(maksSonuçAdet));
                }
                else if (ilçeId > 0)
                {
                    var ilçeRstrnlr = tümRstrnlar.Where(r => r.İletişim.Adres.İlçeId == ilçeId);

                    if (ilçeRstrnlr != null && ilçeRstrnlr.Any())
                        (aramaSonucu as List<Restoran>).AddRange(ilçeRstrnlr.Take(maksSonuçAdet));
                }
                else if (ilId > 0)
                {
                    var ilRstrnlr = tümRstrnlar.Where(r => r.İletişim.Adres.İlId == ilId);

                    if (ilRstrnlr != null && ilRstrnlr.Any())
                        (aramaSonucu as List<Restoran>).AddRange(ilRstrnlr.Take(maksSonuçAdet));
                }

                return aramaSonucu.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<List<Restoran>> BölgedeErzakAra(string aramaDizisi, int ilId, int ilçeId, int semtId)
        {
            IEnumerable<Restoran> aramaSonucu = null;
            const int maksSonuçAdet = 10;

            try
            {
                var bölgeRstrnlar = BölgedeRestoranlarAl(ilId, ilçeId, semtId);

                aramaSonucu = new List<Restoran>();

                if (bölgeRstrnlar != null && bölgeRstrnlar.Any())
                {
                    var rstrnlr = bölgeRstrnlar.Where(r => r.İsim.Contains(aramaDizisi));

                    if (rstrnlr != null && rstrnlr.Any())
                        (aramaSonucu as List<Restoran>).AddRange(rstrnlr.Take(maksSonuçAdet).ToList());

                    if (aramaSonucu.Count() < maksSonuçAdet)
                        (aramaSonucu as List<Restoran>).AddRange(
                            bölgeRstrnlar.Where(r => r.Menüler.Any(m => m.Ad.Contains(aramaDizisi))).Take(maksSonuçAdet));

                    if (aramaSonucu.Count() < maksSonuçAdet)
                        (aramaSonucu as List<Restoran>).AddRange(bölgeRstrnlar.Where(r => r.Menüler.Any(m =>
                                                m.MenüÖğeler.Any(mö => mö.Ad.Contains(aramaDizisi)))).Take(maksSonuçAdet));

                    return aramaSonucu.Any() ? aramaSonucu.Take(maksSonuçAdet).ToList() : null;
                }
                else
                    return null;
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
