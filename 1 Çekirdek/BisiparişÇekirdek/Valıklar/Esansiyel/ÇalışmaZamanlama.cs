using BisiparişÇekirdek.Valıklar.Erzak;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class ÇalışmaZamanlama : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required]
        public int İşletmeId { get; set; }
        [Required]
        public DayOfWeek HaftaGün { get; set; }
        [Required]
        public byte Saatten { get; set; }
        [Required]
        public byte Saate { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)

        #endregion
    }
}
