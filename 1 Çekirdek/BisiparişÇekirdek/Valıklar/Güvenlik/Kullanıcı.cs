using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Güvenlik
{
    public class Kullanıcı : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(100)]
        public string AdSoyad { get; set; }
        [Required]
        public Cinsiyet Cinsiyet { get; set; }
        [StringLength(50)]
        public string Pozisyon { get; set; }
        [Required, StringLength(30)]
        public string Girişİsim { get; set; }
        [NotMapped]
        public string AsılŞifre { get; set; }
        [Required]
        public string KarmaŞifre { get; set; }
        [Required]
        public KullanıcıRol Rol { get; set; }
        public string KaldırmaSebebi { get; set; }
        public DateTime? SonGirişTarihVeZaman { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
