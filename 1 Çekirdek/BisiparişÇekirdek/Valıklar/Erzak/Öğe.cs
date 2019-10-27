using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Depo;
using BisiparişÇekirdek.Valıklar.Esansiyel;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Öğe : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(75)]
        public string Ad { get; set; }
        [StringLength(40)]
        public string Kod { get; set; }
        [StringLength(50)]
        public string BarKod { get; set; }
        [StringLength(50)]
        public string TedarikçiKod { get; set; }
        [StringLength(50)]
        public string TedarikçiBarKod { get; set; }
        [StringLength(250)]
        public string Betimleme { get; set; }
        public int? KategoriId { get; set; }
        public float Fiyat { get; set; }
        //public ÖğeModel Model { get; set; }
        //public ÖğeİşlemKard ÖğeKard { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
