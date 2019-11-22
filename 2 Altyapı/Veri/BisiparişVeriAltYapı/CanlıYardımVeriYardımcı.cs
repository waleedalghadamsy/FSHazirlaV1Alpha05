using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.SistemYönetim;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BisiparişVeriAltYapı
{
    public class CanlıYardımVeriYardımcı
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        public static async Task<İcraSonuç> YeniYardımİstekEkle(Yardımİstek yeniİstek)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var istkEklendi = await vtBğlm.Yardımİstekler.AddAsync(yeniİstek);

                    await vtBğlm.SaveChangesAsync();

                    if (istkEklendi != null && istkEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniİstek.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<İcraSonuç> YeniYardımYanıtEkle(YardımYanıt yeniYanıt)
        {
            try
            {
                using (var vtBğlm = new BisiparişVeriBağlam() { BağlantıDizesi = BisiparişVeriYardımcı.BağlantıDizesi })
                {
                    var yntEklendi = await vtBğlm.YardımYanıtlar.AddAsync(yeniYanıt);

                    await vtBğlm.SaveChangesAsync();

                    if (yntEklendi != null && yntEklendi.Entity.Id > 0)
                        return new İcraSonuç() { BaşarılıMı = true, YeniEklediId = yeniYanıt.Id };
                    else
                        return İcraSonuç.BaşarıSız;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
