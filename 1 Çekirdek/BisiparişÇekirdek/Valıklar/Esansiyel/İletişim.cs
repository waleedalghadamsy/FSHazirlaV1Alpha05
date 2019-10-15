using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public class İletişim : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public virtual YerAdres Adres { get; set; }
        public List<string> EvKaraTelefonler { get; set; }
        public List<string> İşCepTelefonler { get; set; }
        public List<string> ÖzelCepTelefonler { get; set; }
        public List<string> İşEpostalar { get; set; }
        public List<string> ÖzelEpostalar { get; set; }
        [StringLength(250)]
        public string WebsiteAdres { get; set; }
        [StringLength(250)]
        public string FacebookHesap { get; set; }
        [StringLength(80)]
        public string TwitterkHesap { get; set; }
        [StringLength(50)]
        public string İnstagramHesap { get; set; }
        [StringLength(100)]
        public string YouTubeHesap { get; set; }
        [StringLength(20)]
        public string WhatsappNumara { get; set; }
        [StringLength(20)]
        public string ViberNumara { get; set; }
        [ForeignKey("Adres")]
        public int AdresId { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
