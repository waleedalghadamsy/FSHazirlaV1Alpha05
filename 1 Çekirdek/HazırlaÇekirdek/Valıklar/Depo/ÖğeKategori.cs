using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HazırlaÇekirdek.Valıklar.Depo
{
    public class ÖğeKategori : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(35)]
        public string Ad { get; set; }
        [StringLength(75)]
        public string Betimleme { get; set; }
        [NotMapped]
        public List<ÖğeKategori> AltKategoriler { get; set; }
        #endregion

        #region Methods (Metotlar)
        #endregion
    }
}
