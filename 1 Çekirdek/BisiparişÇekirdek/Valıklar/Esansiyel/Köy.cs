using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisaprişÇekirdek.Valıklar.Esansiyel
{
    public class Köy : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(50)]
        public string Ad { get; set; }
        public Semt Semt { get; set; }
        [ForeignKey("Semt")]
        public int SemtId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
