using HazırlaÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazırlaWebArkaUç.Modeller.Güvenlik
{
    public class KullanıcıModel : IdentityUser<int>
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public Kullanıcı Kullanıcı { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
