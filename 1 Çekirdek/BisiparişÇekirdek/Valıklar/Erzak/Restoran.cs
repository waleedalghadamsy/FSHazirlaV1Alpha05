using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Restoran : Kafe
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        public Restoran(string isim) : base(isim)
        {

        }
        #endregion

        #region Properties (Özellikler)
        public RestoranTür Tür { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
