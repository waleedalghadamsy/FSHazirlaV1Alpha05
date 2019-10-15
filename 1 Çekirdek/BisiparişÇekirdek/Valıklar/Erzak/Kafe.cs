using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Kafe : İşyeri
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        public Kafe(string isim) : base(isim)
        {
            ÖzelSektörMü = true;
        }
        #endregion

        #region Properties (Özellikler)
        public TimeSpan ÇalışmaSaatleri { get; set; } //TODO: Should relate each day to time period
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
