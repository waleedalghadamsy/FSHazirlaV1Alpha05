using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.VeriGünlüğü
{
    public class Günlük
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public OlaySeviye Seviye { get; set; }
        [Required, StringLength(10)]
        public string Tarih { get; set; }
        [Required, StringLength(14)]
        public string Zaman { get; set; }
        [Required, StringLength(150)]
        public string Kaynak { get; set; }
        [Required]
        public string Mesaj { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
