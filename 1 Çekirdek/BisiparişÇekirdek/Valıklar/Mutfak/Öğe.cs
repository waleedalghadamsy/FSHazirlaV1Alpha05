using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGoÇekirdek.Valıklar.Depo;

namespace BisaprişÇekirdek.Valıklar.Mutfak
{
    public class Öğe
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Kod { get; set; }
        public string BarKod { get; set; }
        public string TedarikçiKod { get; set; }
        public string TedarikçiBarKod { get; set; }
        public string Betimleme { get; set; }
        public List<byte[]> Resimler { get; set; }
        public ÖğeKategori Kategori { get; set; }
        //public ÖğeModel Model { get; set; }
        //public ÖğeİşlemKard ÖğeKard { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
