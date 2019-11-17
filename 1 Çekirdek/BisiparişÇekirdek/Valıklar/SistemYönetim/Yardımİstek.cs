using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.SistemYönetim
{
    public class Yardımİstek : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int İstekSahibiId { get; set; }
        public DateTime İstekTarihVeZaman { get; set; }
        public string Ayrıntılar { get; set; }
        public YardımİstekDurum Durum { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
