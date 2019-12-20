using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HazırlaÇekirdek.Valıklar.Esansiyel
{
    public class YerAdres : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        //public virtual Ülke Ülke { get; set; }
        [NotMapped]
        public Şehir Şehir { get; set; }
        [NotMapped]
        public İl İl { get; set; }
        [NotMapped]
        public İlçe İlçe { get; set; }
        [NotMapped]
        public Semt Semt { get; set; }
        [NotMapped]
        public Mahalle Mahalle { get; set; }
        [NotMapped]
        public Köy Köy { get; set; }
        [StringLength(7)]
        public string BinaNumerası { get; set; }
        [StringLength(25)]
        public string CaddeSokakAdı { get; set; }
        public float? Enlem { get; set; }
        public float? Boylam { get; set; }
        [StringLength(250)]
        public string GoogleMapsUrl { get; set; }
        [StringLength(150)]
        public string Betimleme { get; set; }
        [StringLength(25)]
        public string Notlar { get; set; }
        //[NotMapped]
        //public string AdresMetin { get { return ToString(); } }
        //[ForeignKey("Ülke")]
        public int ÜlkeId { get; set; }
        //[ForeignKey("Şehir")]
        public int ŞehirId { get; set; }
        //[ForeignKey("İl")]
        public int? İlId { get; set; }
        //[ForeignKey("İlçe")]
        public int? İlçeId { get; set; }
        //[ForeignKey("Semt")]
        public int? SemtId { get; set; }
        //[ForeignKey("Mahalle")]
        public int? MahalleId { get; set; }
        //[ForeignKey("Köy")]
        public int? KöyId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        //public override string ToString()
        //{
        //    return "";
        //    //string.Format("{0}{1}{2}{3}{4}{5}", 
        //    //                    Ülke != null ? Ülke.Ad + " - " : "",
        //    //                    Şehir != null ? Şehir.Ad + " - " : "",
        //    //                    İl != null ? İl.Ad + " - " : "",
        //    //                    İlçe != null ? İlçe.Ad + " - " : "",
        //    //                    Mahalle != null ? Mahalle.Ad + " - " : "",
        //    //                    !string.IsNullOrWhiteSpace(CaddeSokakAdı) ? CaddeSokakAdı : "");
        //}
        public void Check()
        {
            //var x = Koordinatler.
        }
        #endregion
    }
}
