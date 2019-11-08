using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BisiparişWeb.Modeller.İdariBölümler
{
    public class İllerGörünümModel
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        public İllerGörünümModel()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Properties (Özellikler)
        public static List<SelectListItem> İller
        {
            get
            {
                var illerListe = new List<SelectListItem>();

                foreach (var il in BisiparişWebYardımcı.İller)
                    illerListe.Add(new SelectListItem() { Value = il.Id.ToString(), Text = il.Ad });

                return illerListe;
            }
        }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
