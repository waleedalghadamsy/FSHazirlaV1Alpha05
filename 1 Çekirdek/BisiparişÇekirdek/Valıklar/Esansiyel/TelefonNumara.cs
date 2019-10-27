using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class TelefonNumara : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int İletişimId { get; set; }
        public TelefonKullanım Kullanım { get; set; }
        [StringLength(20)]
        public string Numara { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
