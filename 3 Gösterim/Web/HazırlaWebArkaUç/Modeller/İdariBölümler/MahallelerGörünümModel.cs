using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaWebArkaUç.Yardımcılar;

namespace HazırlaWebArkaUç.Modeller.İdariBölümler
{
    public class MahallelerGörünümModel
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static List<SelectListItem> SemtMahalleler(int semtId)
        {
            try
            {
                var mahallelerListe = new List<SelectListItem>();

                foreach (var mhl in Yardımcılar.İdariBölümlerYardımcı.Mahalleler.Where(mh => mh.SemtId == semtId))
                    mahallelerListe.Add(new SelectListItem() { Value = mhl.Id.ToString(), Text = mhl.Ad });

                return mahallelerListe;
            }
            catch (Exception ex)
            {
                Task.Run(async () => await HazırlaWebYardımcı.HataKaydet(ex));
                throw ex;
            }
        }
        #endregion
    }
}
