using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisaprişÇekirdek.Valıklar.Esansiyel
{
    public class İlçe : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(20)]
        public string Ad { get; set; }
        public İl İl { get; set; }
        //public List<Mahalle> Mahalleler { get; set; }
        [NotMapped]
        public List<Semt> Semtler { get; set; }
        [ForeignKey("İl")]
        public int? İlId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
