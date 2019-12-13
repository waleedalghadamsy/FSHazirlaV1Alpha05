using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Muhasebe
{
    public class SiparişÖğe : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int SiparişId { get; set; }
        public int ÖğeId { get; set; }
        public SiparişÖğeTür Tür { get; set; }
        public byte Miktar { get; set; }
        [StringLength(50)]
        public string Ayrıntılar { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
