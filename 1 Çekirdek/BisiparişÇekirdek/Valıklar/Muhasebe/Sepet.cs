using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public int MüşteriId { get; set; }
        [Required]
        public DateTime TarihVeZaman { get; set; }
        [Required]
        public DateTime Hazırlanacağı { get; set; }
        [StringLength(10)]
        public string MasaSayısı { get; set; }
        public bool? DışMekanSeçimiMi { get; set; }
        [Required]
        public bool PaketMi { get; set; }
        [NotMapped]
        public List<SepetÖğe> Öğeler { get; set; }
        public int? KuponId { get; set; }
        public int? PromosyonId { get; set; }
        public string Ayrıntılar { get; set; }
        public float ToplamFiyat { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
