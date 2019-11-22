using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Değerlendirme
{
    public class MüşteriDeğerleme : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int MüşteriId { get; set; }
        public DeğerelendiVarlık VarlıkTip { get; set; }
        public int VarlıkId { get; set; }
        public byte? Değer { get; set; }
        public string Yorum { get; set; }
        public DateTime TarihVeZaman { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
