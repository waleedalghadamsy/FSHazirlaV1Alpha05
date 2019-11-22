using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Menü : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [Required]
        public int RestoranId { get; set; }
        [NotMapped]
        public List<MenüÖğe> MenüÖğeler { get; set; }
        [Required]
        public bool Onaylandı { get; set; }
        public string ReddetSebebi { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
