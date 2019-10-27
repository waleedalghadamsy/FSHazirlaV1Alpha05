using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiparişÇekirdek.Valıklar.Depo
{
    public abstract class ÖğeKod
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int Id { get; set; }
        //public ÖğeKodTip Tip { get; set; }
        public abstract int HashCode { get; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
