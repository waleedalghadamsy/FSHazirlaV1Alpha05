using System;
using System.Collections.Generic;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class Bildirim : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int YükId { get; set; }
        public object Yük { get; set; }
        public BildirimKaynakHedef Kaynak { get; set; }
        public BildirimKaynakHedef Hedef { get; set; }
        public BildirimDurum Durum { get; set; }
        public string Mesaj { get; set; }
        public DateTime Zaman { get; set; }
        //public int? OnayId { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
