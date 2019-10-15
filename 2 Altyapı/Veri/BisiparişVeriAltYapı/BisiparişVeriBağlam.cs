using BisiparişÇekirdek.Valıklar.Esansiyel;
using BisiparişÇekirdek.Valıklar.Erzak;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişÇekirdek.Valıklar.Muhasebe;

namespace BisiparişVeriAltYapı
{
    public class BisiparişVeriBağlam : DbContext
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public DbSet<Ülke> Ülkeler { get; set; }
        public DbSet<Şehir> Şehirler { get; set; }
        public DbSet<İl> İller { get; set; }
        public DbSet<İlçe> İlçeler { get; set; }
        public DbSet<Kişi> Kişiler { get; set; }
        public DbSet<YerAdres> YerAdresler { get; set; }
        public DbSet<İletişim> İletişimler { get; set; }
        public DbSet<İşyeri> İşyeriler { get; set; }
        public DbSet<İşyeriİletişim> İşyeriİletişimler { get; set; }
        public DbSet<Müşteri> Müşteriler { get; set; }
        public DbSet<Menü> Menüler { get; set; }
        public DbSet<Öğe> Öğeler { get; set; }
        public DbSet<Öğün> Öğünler { get; set; }
        public DbSet<Kafe> Kafeer { get; set; }
        public DbSet<Restoran> Restoranlar { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<KullanıcılarGrup> KullanıcılarGruplar { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<Sipariş> Siparişler { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        #endregion
    }
}
