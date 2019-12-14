using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Erzak
{
    public class MenüÖğe : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required]
        public int MenüId { get; set; }
        [Required, StringLength(40)]
        public string Ad { get; set; }
        [Required]
        public SiparişÖğeTür Tür { get; set; }
        public byte[] Fotoğraf { get; set; }
        public float Fiyat { get; set; }
        [StringLength(100)]
        public string Betimleme { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
