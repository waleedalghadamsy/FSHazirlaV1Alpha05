using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Muhasebe
{
    public class Sipariş : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required]
        public int MüşteriId { get; set; }
        [Required]
        public int RestoranId { get; set; }
        [Required]
        public DateTime TarihVeZaman { get; set; }
        public DateTime? GelmeZamanı { get; set; }
        public DateTime? TeslimTarihVeZaman { get; set; }
        public byte? MasaAdedi { get; set; }
        //[Required]
        //public virtual Müşteri Müşteri { get; set; }
        public bool PaketMi { get; set; }
        public string QrKod { get; set; }
        public byte[] QrKodResim { get; set; }
        public string Ayrıntılar { get; set; }
        public string İptalSebebi { get; set; }
        //[ForeignKey("Müşteri")]
        public int SepetId { get; set; }
        public SiparişDurum Durum { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
