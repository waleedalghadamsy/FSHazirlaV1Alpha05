using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BisiparişWeb.Modeller.Güvenlik
{
    public class KullanıcılarGrupModel : IdentityRole<int>
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public KullanıcılarGrup Grup { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
