using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BisiparişWeb.Modeller.İdariBölümler
{
    public class SemtlerGörünümModel
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static List<SelectListItem> İlçeSemtler(int ilçeId)
        {
            try
            {
                var semtlerListe = new List<SelectListItem>();

                foreach (var semt in BisiparişWebYardımcı.Semtler.Where(smt => smt.İlçeId == ilçeId))
                    semtlerListe.Add(new SelectListItem() { Value = semt.Id.ToString(), Text = semt.Ad });

                return semtlerListe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
