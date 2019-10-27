using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public class Kafe : İşyeri
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        public Kafe()
        {
        }

        public Kafe(string isim) : base(isim)
        {
            ÖzelSektörMü = true;
        }
        #endregion

        #region Properties (Özellikler)
        [NotMapped]
        public List<Menü> Menüler { get; set; }
        [NotMapped]
        public List<byte[]> Fotoğraflar { get; set; }
        [NotMapped]
        public List<ÇalışmaZamanlama> ÇalışmaZamanlamalar { get; set; }
        public bool Onaylı { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
