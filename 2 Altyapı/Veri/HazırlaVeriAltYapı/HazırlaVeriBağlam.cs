using HazırlaÇekirdek.Valıklar.Esansiyel;
using HazırlaÇekirdek.Valıklar.Erzak;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using HazırlaÇekirdek.Valıklar.Güvenlik;
using HazırlaÇekirdek.Valıklar.Muhasebe;
using HazırlaÇekirdek.Valıklar.Değerlendirme;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaÇekirdek.Valıklar.SistemYönetim;

namespace HazırlaVeriAltYapı
{
    public class HazırlaVeriBağlam : DbContext
    {
        #region Data Members (Veri Üyeler)
        #endregion

        #region Constructors (Oluşturucular) (Yapıcılar)
        #endregion

        #region Properties (Özellikler)
        public string BağlantıDizesi { get; set; }
        //public DbSet<TemelVarlık> Varlıklar { get; set; }
        public DbSet<Ülke> Ülkeler { get; set; }
        public DbSet<Şehir> Şehirler { get; set; }
        public DbSet<İl> İller { get; set; }
        public DbSet<İlçe> İlçeler { get; set; }
        public DbSet<Semt> Semtler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }
        //public DbSet<Kişi> Kişiler { get; set; }
        public DbSet<YerAdres> YerlerAdresler { get; set; }
        public DbSet<İletişim> İletişimler { get; set; }
        //public DbSet<İşyeri> İşyeriler { get; set; }
        public DbSet<İşyeriİletişim> İşyeriİletişimler { get; set; }
        public DbSet<TelefonNumara> TelefonNumaralar { get; set; }
        public DbSet<EpostaAdres> EpostaAdresler { get; set; }
        public DbSet<Müşteri> Müşteriler { get; set; }
        public DbSet<Öğe> Öğeler { get; set; }
        public DbSet<İçecek> İçecekler { get; set; }
        public DbSet<Yemek> Yemekler { get; set; }
        public DbSet<Öğün> Öğünler { get; set; }
        public DbSet<ÖğünÖğe> ÖğünlerÖğeler { get; set; }
        //public DbSet<Kafe> Kafeler { get; set; }
        public DbSet<Restoran> Restoranlar { get; set; }
        public DbSet<ÇalışmaZamanlama> ÇalışmaZamanlamalar { get; set; }
        public DbSet<Menü> Menüler { get; set; }
        public DbSet<MenüÖğe> MenülerÖğeler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<VarlıkKategori> VarlıklarKategoriler { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<KullanıcıRestoran> KullanıcılarRestoranlar { get; set; }
        //public DbSet<KullanıcılarGrup> KullanıcılarGruplar { get; set; }
        public DbSet<İşlem> İşlemler { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        //public DbSet<Fatura> Faturalar { get; set; }
        //public DbSet<FaturaÖğe> FaturalarÖğeler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetÖğe> SepetlerÖğeler { get; set; }
        public DbSet<Sipariş> Siparişler { get; set; }
        public DbSet<SiparişÖğe> SiparişlerÖğeler { get; set; }
        public DbSet<Kupon> Kuponlar { get; set; }
        public DbSet<Promosyon> Promosyonlar { get; set; }
        public DbSet<MüşteriDeğerleme> Değerlemeler { get; set; }
        //public DbSet<MüşteriFavoriKafe> FavoriKafeler { get; set; }
        public DbSet<MüşteriFavoriRestoran> FavoriRestoranlar { get; set; }
        public DbSet<MüşteriFavoriÖğün> FavoriÖğünler { get; set; }
        public DbSet<MüşteriFavoriYemek> FavoriYemekler { get; set; }
        public DbSet<MüşteriFavoriİçecek> Favoriİçecekler { get; set; }
        public DbSet<VarlıkFotoğraf> Fotoğraflar { get; set; }
        public DbSet<Yardımİstek> Yardımİstekler { get; set; }
        public DbSet<YardımYanıt> YardımYanıtlar { get; set; }
        public DbSet<Sistemİşlem> Sistemİşlemler { get; set; }
        public DbSet<Günlük> BilgiGünlük { get; set; }
        #endregion

        #region Methods (Metotlar) (Yöntemler)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //BağlantıDizesi = "Data Source=.\\sqlexpr16; Initial Catalog=HazırlaVT; Persist Security Info=True; "
                //    + "user id=waleed; password=AbcXyz123;";

                //BağlantıDizesi = "User ID = waleed; Password = AbcXyz123; Server = localhost; Port = 5432; Database = hazırlavt;"
                //    + "Integrated Security = true; Pooling = true;";

                //optionsBuilder.UseSqlServer(BağlantıDizesi);
                optionsBuilder.UseNpgsql(BağlantıDizesi);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.
        //}
        #endregion
    }
}
