using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazırlaWebArkaUç.Modeller.İdariBölümler
{
    public class İlçelerGörünümModel
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static List<SelectListItem> İlİlçeler(int ilId)
        {
            try
            {
                var ilçelerListe = new List<SelectListItem>();

                foreach (var ilçe in Yardımcılar.İdariBölümlerYardımcı.İlçeler.Where(ilçe => ilçe.İlId == ilId))
                    ilçelerListe.Add(new SelectListItem() { Value = ilçe.Id.ToString(), Text = ilçe.Ad });

                return ilçelerListe;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
