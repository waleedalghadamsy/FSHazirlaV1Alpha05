using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class Şehir : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [StringLength(50)]
        public string İngilizceAdı { get; set; }
        //public virtual Ülke Ülke { get; set; }
        //[ForeignKey("Ülke")]
        public int ÜlkeId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
