using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Muhasebe
{
    public class FaturaÖğe : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int FaturaId { get; set; }
        public int ÖğeId { get; set; }
        public byte Miktar { get; set; }
        public float İndirim { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
