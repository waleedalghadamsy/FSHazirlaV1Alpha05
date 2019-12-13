using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class EpostaAdres : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int İletişimId { get; set; }
        public EpostaAdresKullanım Kullanım { get; set; }
        [StringLength(40)]
        public string Adres { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
