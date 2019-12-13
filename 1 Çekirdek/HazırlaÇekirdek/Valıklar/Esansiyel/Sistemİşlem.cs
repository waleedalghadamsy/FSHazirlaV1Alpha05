using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class Sistemİşlem
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public İşlemTip Tip { get; set; }
        [Required]
        public int ÖğeId { get; set; }
        [Required]
        public int KullanıcıId { get; set; }
        [Required, StringLength(10)]
        public string Tarih { get; set; }
        [Required, StringLength(14)]
        public string Zaman { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
