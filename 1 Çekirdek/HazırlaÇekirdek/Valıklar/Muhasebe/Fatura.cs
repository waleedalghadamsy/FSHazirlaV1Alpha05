using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Muhasebe
{
    public class Fatura : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public string Numara { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Müşteri Müşteri { get; set; }
        public virtual Sipariş Sipariş { get; set; }
        public List<FaturaÖğe> FaturaÖğeler { get; set; }
        [ForeignKey("Müşteri")]
        public int MüşteriId { get; set; }
        [ForeignKey("Sipariş")]
        public int SiparişId { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
