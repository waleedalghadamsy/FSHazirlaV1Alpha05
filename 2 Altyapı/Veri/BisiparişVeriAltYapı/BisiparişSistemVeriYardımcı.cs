﻿using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BisiparişVeriAltYapı
{
    public class BisiparişSistemVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static void İşlemKaydet(Sistemİşlem işlem)
        {
            try
            {
                Task.Run(async () =>
                {
                    using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                    {
                        işlem.Tarih = DateTime.Now.ToString("yyyy-MM-dd");
                        işlem.Zaman = DateTime.Now.ToString("HH:mm:ss.fffff");

                        var istkEklendi = await vtBğlm.Sistemİşlemler.AddAsync(işlem);

                        await vtBğlm.SaveChangesAsync();
                    }
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await BisiparişVeriYardımcı.GünlükKaydet(OlaySeviye.Hata, ex));
                throw ex;
            }
        }
        #endregion
    }
}
