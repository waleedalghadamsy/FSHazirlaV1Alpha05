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
        public static async Task RestoranlarAl()
        {
            try
            {
                MemCache.Set("Restoranlar", await RestoranlarVeriYardımcı.RestoranlarAl());
            }
            catch (Exception ex)
            {
                await HazırlaVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex);
                throw ex;
            }
        }
        #endregion
    }
}
