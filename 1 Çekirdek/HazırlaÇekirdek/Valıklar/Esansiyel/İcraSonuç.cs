using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class İcraSonuç
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public bool BaşarılıMı { get; set; }
        public string Mesaj { get; set; }
        public int YeniEklediId { get; set; }
        public static İcraSonuç Başarılı => new İcraSonuç() { BaşarılıMı = true };
        public static İcraSonuç BaşarıSız => new İcraSonuç() { BaşarılıMı = false, Mesaj = "Bir hata var." };
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
