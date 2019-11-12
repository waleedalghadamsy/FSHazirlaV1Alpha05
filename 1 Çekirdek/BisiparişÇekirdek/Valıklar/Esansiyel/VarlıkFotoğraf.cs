using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class VarlıkFotoğraf : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public FotoğrafVarlıkTip VarlıkTip { get; set; }
        public int VarlıkId { get; set; }
        public byte[] Fotoğraf { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
