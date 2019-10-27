using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class Semt : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [StringLength(5)]
        public string PostaKodu { get; set; }
        public virtual İlçe İlçe { get; set; }
        [NotMapped]
        public List<Mahalle> Mahalleler { get; set; }
        [NotMapped]
        public List<Köy> Köyler { get; set; }
        [ForeignKey("İlçe")]
        public int? İlçeId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
