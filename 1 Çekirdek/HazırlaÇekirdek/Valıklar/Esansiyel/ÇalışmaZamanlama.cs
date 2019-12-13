using HazırlaÇekirdek.Valıklar.Erzak;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
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
        [Required, StringLength(5)]
        public string Saatten { get; set; }
        [Required, StringLength(5)]
        public string Saate { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)

        #endregion
    }
}
