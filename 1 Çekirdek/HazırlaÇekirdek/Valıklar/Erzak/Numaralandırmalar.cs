using System;
using System.Collections.Generic;
using System.Text;

namespace HazırlaÇekirdek.Valıklar.Erzak
{
    [Flags]
    public enum RestoranTürler : short
    {
        Hiçbiri,
        YeVeKalk = 1, 
        Yemek = 2,
        Tatlıcı = 4,
        Kahvaltı = 8,
        LüksYemek = 16,
        Lokanta = 32,
        CafeVeİçecek = 64,
        SokakLezzetleri = 128,
        Pastaneler = 256,
        RomantikMekanlar = 512
    }

    public enum YerTür : byte
    {
        Hiçbiri, 
        Kafe = 1,
        Restoran
    }

    [Flags]
    public enum RestoranHizmetler : long
    {
        Hiçbiri, 
        Kahvaltı = 1,
        TatlıVePasta = 2,
        EvYemeği = 4,
        Brunch = 8,
        LüksYemek = 16,
        VeganSeçenekler = 32,
        AçıkBüfe = 64,
        GrupYemeği = 128,
        Mescit = 256,
        ÇocukluAilelerİçinUygun = 512,
        İşYemeğiİçinUygun = 1024,
        OturmaAlanıYok = 2048,
        İçMekan = 4096,
        DışMekan = 8192,
        BalkonVeyaTeras = 16384,
        DenizKenarı = 32768,
        GölKenarı = 65536,
        Doğaİleİçİçe = 131072,
        ŞehirManzarası = 262144,
        EngelliDostu = 524288,
        EvcilHayvanDostu = 1048576,
        VIPYemekSalonu = 2097152,
        SigaraİçmeAlanı = 4194304,
        SelfServis = 8388608,
        MasaHazırlat = 16777216,
        GelAl = 33554432,
        Fasıl = 67108864,
        Nargile = 134217728,
        //AlkolServisiVar,
        AlkolServisiYok = 268435456,
        MasaOyunları = 536870912,
        CanlıMüzik = 1073741824,
        MaçYayını = 2147483648,
        DjPerformansı = 4294967296,
        Wifi = 8589934592,
        MobilŞarjAleti = 17179869184,
        OtoparkAlanı = 34359738368,
        Vale = 68719476736,
        Huzur = 137438953472,
        DoğumGünü = 274877906944
    }

    [Flags]
    public enum Mutfaklar : int
    {
        Hiçbiri,
        BalıkVeDenizÜrünleri = 1,
        Börek = 2,
        Burger = 4, 
        Cafe = 8,
        ÇiğKöfte = 16,
        Dondurma = 32, 
        Döner = 64,
        DünyaMutfağı = 128,
        EvYemekleri = 256,
        FastFoodVeSandwich = 512,
        AsyaMutfağıVeSushi = 1024,
        Kahvaltı = 2048, 
        Kahve = 4096,
        KebapVeTürkMutfağı = 8192, 
        Köfte = 16384,
        KokoreçVeMidye = 32768, 
        Kumpir = 65536,
        PastaVeTatlı = 131072, 
        Pide = 262144, 
        Pilav = 524288, 
        Pizza = 1048576, 
        Steak = 2097152,
        Tantuni = 4194304, 
        Tavuk = 8388608,
        İtalyanMutfağı = 16777216, 
        Nargile = 33554432
    }

    public enum İçecekTür : byte
    {
        Hiçbiri,
        Çay,
        Kahve,

        Salep
    }

    public enum İçecekSıcaklık : byte
    {
        Hiçbiri,
        Soğuk,
        Sıcak
    }

    public enum SiparişÖğeTür : byte
    {
        Hiçbiri,
        Yemek,
        İçecek,
        Öğün
    }

    public enum ÖğünÖğeTür
    {
        Hiçbiri,
        İçecek,
        Yemek
    }

    //public enum YemekKategori
    //{

    //}

    //public enum İçecekKategori
    //{

    //}
}
