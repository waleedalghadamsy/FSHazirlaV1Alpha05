using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Muhasebe
{
    public class MüşterilerKuponlar : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int MüşteriId { get; set; }
        public int KuponId { get; set; }
        public DateTime Kullanıldığında { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
