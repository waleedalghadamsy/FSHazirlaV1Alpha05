using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class İl : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [Required]
        public byte Plaka { get; set; }
        [NotMapped]
        public List<İlçe> İlçeler { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
