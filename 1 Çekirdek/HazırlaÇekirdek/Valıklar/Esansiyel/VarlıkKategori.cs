using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class VarlıkKategori : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required]
        public int VarlıkId { get; set; }
        [Required]
        public VarlıkTür VarlıkTür { get; set; }
        [Required]
        public int KategoriId { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
