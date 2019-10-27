using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Erzak
{
    public enum RestoranTür : byte
    {
        YeVeKalk = 1, 
        Yemek,
        Tatlıcı,
        Kahvaltı,
        LüksYemek,
        Lokanta,
        CafeVeİçecek,
        SokakLezzetleri,
        Pastaneler,
        RomantikMekanlar
    }

    public enum YerTür : byte
    {
        Kafe = 1,
        Restoran
    }

    public enum İçecekTür : byte
    {
        Çay = 1,
        Kahve,

        Salep
    }

    public enum İçecekSıcaklık : byte
    {
        Soğuk = 1,
        Sıcak
    }

    public enum SiparişÖğeTür
    {
        İçecek = 1,
        Yemek,
        Öğün
    }

    public enum ÖğünÖğeTür
    {
        İçecek = 1,
        Yemek
    }

    //public enum YemekKategori
    //{

    //}

    //public enum İçecekKategori
    //{

    //}
}
