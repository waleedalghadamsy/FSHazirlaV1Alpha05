using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Öğün : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [StringLength(100)]
        public string Ad { get; set; }
        [StringLength(300)]
        public string Betimleme { get; set; }

        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
