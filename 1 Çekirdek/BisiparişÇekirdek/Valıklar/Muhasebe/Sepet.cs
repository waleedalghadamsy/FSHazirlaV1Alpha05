using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Muhasebe
{
    public class Sepet : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public DateTime TarihVeZaman { get; set; }
        public Müşteri Müşteri { get; set; }
        public bool PaketMi { get; set; }
        public List<SepetÖğe> Öğeler { get; set; }
        public string Ayrıntılar { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
