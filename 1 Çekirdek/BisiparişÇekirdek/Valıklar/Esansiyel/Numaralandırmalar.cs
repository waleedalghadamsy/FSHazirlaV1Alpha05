using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiparişÇekirdek.Valıklar.Esansiyel
{
    public enum Cinsiyet : byte
    {
        Erkek = 1,
        Kadın
    }

    public enum HayatDurum : byte
    {
        Canlı = 1,
        Ölü
    }

    public enum SosyalDurum : byte
    {
        Hiçbiri, Bekâr, Evli, Boşanmış, Dul
    }

    public enum ÖlçümBoyut : byte
    {
        Hiçbiri, Parça, Uzunluk, Kütle, Hacim
    }

    public enum ParçaBirim : short
    {
        Hiçbiri, TekParça = 1, On = 10, Düzine = 12, Elli = 50, Yüz = 100, BeşYüz = 500, Bin = 1000
    }

    public enum UzunlukBirim
    {
        Hiçbiri,
        Mikrometre = 1, Milimetre = 1000, Santimetre = 10000, İnç = 25400, Ayak = 304800, Yarda = 914400,
        Metre = 1000000, Kilometre = 1000000000, Mil = 1609344000
    }

    public enum KütleBirim : ulong
    {
        Hiçbiri, Nanogram = 1, Mikrogram = 1000, Miligram = 1000000, Ons = 28349523, Pound = 453592370,
        Karat = 200000000, Gram = 1000000000, Kilogram = 1000000000000, Ton = 1000000000000000
    }

    public enum HacimBirim : short
    {
        Hiçbiri, SantimetreKüp = 1, Mililitre = 1, Litre = 1000
    }

    public enum ÖğeKodTip : byte
    {
        SeriNumarasıKod = 1,
        UluslararasıBarkod,
        SonKullanmaTarihiKod
    }

    public enum TelefonKullanım : byte
    {
        EvKara = 1,
        İşCep,
        ÖzelCep
    }

    public enum EpostaAdresKullanım : byte
    {
        İş = 1,
        Özel
    }

    public enum OnayDurum : byte
    {
        Beklemede = 1,
        Onaylı,
        Reddetti
    }

    public enum BildirimDurum : byte
    {
        Bekleyen = 1,
        TeslimEdildi,
        Okundu
    }

    public enum BildirimKaynakHedef : byte
    {
        
    }

    public enum VarlıkTür : byte
    {
        Yemek = 1,
        İçecek,
        Menü
    }

    public enum FotoğrafVarlıkTip : byte
    {
        Yemek = 1,
        İçecek,
        Öğün,
        MenüÖğe,
        Kafe,
        Restoran
    }

    public enum İşlemTip : byte
    {
        YeniRestoranEkledi = 1,
        RestoranDeğiştirdi,
        YeniMenüEkledi,
        MenüDeğiştirdi,
        YeniSepetEkledi,
        YeniSiparişEkledi,
        SiparişDeğiştirdi,
        SiparişOnaylandı,
        SiparişHazırlanıyor,
        SiparişHazırlandı,
        SiparişTeslimEdildi,
        SiparişİptalEdildi,
        ParaÖdendi,
        YeniKuponEkledi,
        YeniPromosyonEkledi,
        KuponKullanıldı,
        PromosyonKullanıldı,
        YeniKullanıcıEkledi,
        KullanıcıDeğiştirdi,
        ŞifreDeğiştirdi,
        KullanıcıGirişDenemdi,
        KullanıcıGirişti,
        KullanıcıGirişBaşarısız,
        KullanıcıÇıkışYaptı,
        KullanıcıOtomatikÇıkış,
        KullanıcıKaldırıldı
    }
}
