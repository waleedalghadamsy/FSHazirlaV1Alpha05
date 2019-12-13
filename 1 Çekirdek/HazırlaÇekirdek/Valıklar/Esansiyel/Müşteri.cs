using HazırlaÇekirdek.Valıklar.Değerlendirme;
using HazırlaÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class Müşteri : Kişi
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public DateTime? SonGiriş { get; set; }
        [NotMapped]
        public List<MüşteriFavoriKafe> FavoriKafeler { get; set; }
        [NotMapped]
        public List<MüşteriFavoriRestoran> FavoriRestoranlar { get; set; }
        [NotMapped]
        public List<MüşteriFavoriYemek> FavoriYemekler { get; set; }
        [NotMapped]
        public List<MüşteriFavoriİçecek> Favoriİçecekler { get; set; }
        [NotMapped]
        public List<MüşteriFavoriÖğün> FavoriÖğünler { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
