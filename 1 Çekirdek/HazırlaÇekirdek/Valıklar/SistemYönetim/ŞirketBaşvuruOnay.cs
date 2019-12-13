using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.SistemYönetim
{
    public class ŞirketBaşvuruOnay : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required]
        public Erzak.YerTür BaşvuruSahibiTür { get; set; }
        [Required]
        public int BaşvuruSahibiId { get; set; }
        [Required]
        public DateTime TarihVeZaman { get; set; }
        [Required]
        public Esansiyel.OnayDurum Durum { get; set; }
        [Required]
        public string RetSebep { get; set; }
        [Required]
        public int KullanıcıId { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
