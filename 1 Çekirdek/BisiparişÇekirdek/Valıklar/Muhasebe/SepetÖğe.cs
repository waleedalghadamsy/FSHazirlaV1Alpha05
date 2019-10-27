using BisiparişÇekirdek.Valıklar.Erzak;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Muhasebe
{
    public class SepetÖğe
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int ÖğeId { get; set; }
        public SiparişÖğeTür Tür { get; set; }
        public byte Miktar { get; set; }
        public string Ayrıntılar { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
