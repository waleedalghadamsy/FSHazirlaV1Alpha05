using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Muhasebe
{
    public enum İşlemTip : byte
    {
        Satış = 1,
        Ödeme,
        BisiparişOran,
        Anlaşma
    }
    
    public enum SiparişDurum : byte
    {
        Hiçbiri,
        SiparişEdildi,
        Reddetti,
        İptalEdildi,
        OnayBeklemede,
        ServisEdilmeli,
        Hazırlanıyor,
        Hazır,
        Teslimdi
    }

    public enum ÖdemeYöntemler : byte
    {
        Nakit = 1,

    }
}
