using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BisaprişÇekirdek.Valıklar.Esansiyel
{
    public class İletişim : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        
        public YerAdres Adres { get; set; }
        public List<string> EvKaraTelefonler { get; set; }
        public List<string> İşCepTelefonler { get; set; }
        public List<string> ÖzelCepTelefonler { get; set; }
        public List<string> İşEpostalar { get; set; }
        public List<string> ÖzelEpostalar { get; set; }
        public string WebsiteAdres { get; set; }
        public string FacebookHesap { get; set; }
        public string TwitterkHesap { get; set; }
        public string İnstagramHesap { get; set; }
        public string WhatsappNumara { get; set; }
        public string ViberNumara { get; set; }
        #endregion

        #region Methods (Yöntemler)
        #endregion
    }
}
