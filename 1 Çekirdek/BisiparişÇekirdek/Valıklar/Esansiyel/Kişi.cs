using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class Kişi : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        [Required, StringLength(20)]
        public string İlkAdı { get; set; }
        [StringLength(20)]
        public string BabaAdı { get; set; }
        [StringLength(20)]
        public string DedeAdı { get; set; }
        [Required, StringLength(20)]
        public string SoyAdı { get; set; }
        [NotMapped]
        public string AdıSoyadı
        {
            get
            {
                return System.Text.RegularExpressions.Regex.Replace(
                        string.Format("{0} {1} {2} {3}", İlkAdı, BabaAdı ?? "", DedeAdı ?? "", SoyAdı ?? ""), 
                        @"\s+", " ").Trim();
            }
        }
        public DateTime? DoğumTarihi { get; set; }
        public YerAdres DoğumYeri { get; set; }
        public Ülke Milliyet { get; set; }
        [Required]
        public Cinsiyet Cinsiyet { get; set; }
        [Required]
        public HayatDurum HayatDurum { get; set; }
        public SosyalDurum? SosyalDurum { get; set; }
        [StringLength(12)]
        public string KimlikNumara { get; set; }
        //public List<Pasaport> Pasaportlar { get; set; }
        public İletişim İletişim { get; set; }
        public byte[] Fotoğraf { get; set; }
        [ForeignKey("DoğumYeri")]
        public int DoğumYeriId { get; set; }
        [ForeignKey("Milliyet")]
        public int MilliyetId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
