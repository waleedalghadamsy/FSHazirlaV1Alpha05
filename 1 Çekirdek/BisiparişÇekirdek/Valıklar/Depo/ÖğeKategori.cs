using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisaprişÇekirdek.Valıklar.Depo
{
    public class ÖğeKategori
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Betimleme { get; set; }
        public List<ÖğeKategori> AltKategoriler { get; set; }
        #endregion

        #region Methods (Metotlar)
        #endregion
    }
}
