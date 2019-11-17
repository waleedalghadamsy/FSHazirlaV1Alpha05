using BisiparişÇekirdek.Valıklar.Esansiyel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.SistemYönetim
{
    public class YardımYanıt : TemelVarlık
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public int İstekId { get; set; }
        public DateTime İslemTarihVeZaman { get; set; }
        public string Yanıt { get; set; }
        public string İçNotlar { get; set; }   
        public int İşlemciId { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
