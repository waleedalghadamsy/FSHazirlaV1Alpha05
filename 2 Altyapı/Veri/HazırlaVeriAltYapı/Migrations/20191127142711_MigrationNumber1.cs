using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HazırlaVeriAltYapı.Migrations
{
    public partial class MigrationNumber1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilgiGünlük",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seviye = table.Column<byte>(nullable: false),
                    Tarih = table.Column<string>(maxLength: 10, nullable: false),
                    Zaman = table.Column<string>(maxLength: 14, nullable: false),
                    Kaynak = table.Column<string>(maxLength: 150, nullable: false),
                    Mesaj = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgiGünlük", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ÇalışmaZamanlamalar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İşletmeId = table.Column<int>(nullable: false),
                    HaftaGün = table.Column<int>(nullable: false),
                    Saatten = table.Column<string>(maxLength: 5, nullable: false),
                    Saate = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÇalışmaZamanlamalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Değerlemeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    VarlıkTip = table.Column<byte>(nullable: false),
                    VarlıkId = table.Column<int>(nullable: false),
                    Değer = table.Column<byte>(nullable: true),
                    Yorum = table.Column<string>(nullable: true),
                    TarihVeZaman = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Değerlemeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpostaAdresler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İletişimId = table.Column<int>(nullable: false),
                    Kullanım = table.Column<byte>(nullable: false),
                    Adres = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaAdresler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favoriİçecekler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    İçecekId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoriİçecekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriÖğünler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    ÖğünId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriÖğünler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriRestoranlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    RestoranId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriRestoranlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriYemekler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    YemekId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriYemekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotoğraflar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    VarlıkTip = table.Column<byte>(nullable: false),
                    VarlıkId = table.Column<int>(nullable: false),
                    Fotoğraf = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotoğraflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    YerId = table.Column<int>(nullable: false),
                    YerTür = table.Column<byte>(nullable: false),
                    Bakiye = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İlçeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 20, nullable: false),
                    İlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlçeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İletişimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    WebsiteAdres = table.Column<string>(maxLength: 250, nullable: true),
                    FacebookHesap = table.Column<string>(maxLength: 250, nullable: true),
                    TwitterkHesap = table.Column<string>(maxLength: 80, nullable: true),
                    İnstagramHesap = table.Column<string>(maxLength: 50, nullable: true),
                    YouTubeHesap = table.Column<string>(maxLength: 100, nullable: true),
                    WhatsappNumara = table.Column<string>(maxLength: 20, nullable: true),
                    ViberNumara = table.Column<string>(maxLength: 20, nullable: true),
                    AdresId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İletişimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    Plaka = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İşlemler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Tip = table.Column<byte>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false),
                    YerId = table.Column<int>(nullable: false),
                    YerTür = table.Column<byte>(nullable: false),
                    Değer = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşlemler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    RestoranId = table.Column<int>(nullable: false),
                    TemelKategoriId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    AdSoyad = table.Column<string>(maxLength: 100, nullable: false),
                    Cinsiyet = table.Column<byte>(nullable: false),
                    Pozisyon = table.Column<string>(maxLength: 50, nullable: true),
                    Girişİsim = table.Column<string>(maxLength: 30, nullable: false),
                    KarmaŞifre = table.Column<string>(nullable: false),
                    EPostaAdres = table.Column<string>(maxLength: 150, nullable: false),
                    MobilNumara = table.Column<string>(maxLength: 30, nullable: false),
                    Rol = table.Column<int>(nullable: false),
                    KaldırmaSebebi = table.Column<string>(nullable: true),
                    SonGirişTarihVeZaman = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KullanıcılarRestoranlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    KullanıcıId = table.Column<int>(nullable: false),
                    RestoranId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullanıcılarRestoranlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kuponlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Kıymet = table.Column<float>(nullable: false),
                    İndirimOranı = table.Column<byte>(nullable: false),
                    GeçerlilikSüresi = table.Column<DateTime>(nullable: false),
                    Şart = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuponlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    SemtId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menüler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    RestoranId = table.Column<int>(nullable: false),
                    Onaylandı = table.Column<bool>(nullable: false),
                    ReddetSebebi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menüler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenülerÖğeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MenüId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 35, nullable: false),
                    Tür = table.Column<byte>(nullable: false),
                    Fiyat = table.Column<float>(nullable: false),
                    Betimleme = table.Column<string>(maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenülerÖğeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Müşteriler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İlkAdı = table.Column<string>(maxLength: 20, nullable: false),
                    BabaAdı = table.Column<string>(maxLength: 20, nullable: true),
                    DedeAdı = table.Column<string>(maxLength: 20, nullable: true),
                    SoyAdı = table.Column<string>(maxLength: 20, nullable: false),
                    DoğumTarihi = table.Column<DateTime>(nullable: true),
                    Cinsiyet = table.Column<byte>(nullable: false),
                    HayatDurum = table.Column<byte>(nullable: false),
                    SosyalDurum = table.Column<byte>(nullable: true),
                    KimlikNumara = table.Column<string>(maxLength: 12, nullable: true),
                    Fotoğraf = table.Column<byte[]>(nullable: true),
                    DoğumYeriId = table.Column<int>(nullable: true),
                    MilliyetId = table.Column<int>(nullable: true),
                    İletişimId = table.Column<int>(nullable: true),
                    SonGiriş = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müşteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Öğeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 75, nullable: false),
                    Kod = table.Column<string>(maxLength: 40, nullable: true),
                    BarKod = table.Column<string>(maxLength: 50, nullable: true),
                    TedarikçiKod = table.Column<string>(maxLength: 50, nullable: true),
                    TedarikçiBarKod = table.Column<string>(maxLength: 50, nullable: true),
                    Betimleme = table.Column<string>(maxLength: 250, nullable: true),
                    KategoriId = table.Column<int>(nullable: true),
                    Fiyat = table.Column<float>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Tür = table.Column<byte>(nullable: true),
                    Sıcaklık = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Öğeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Öğünler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 100, nullable: true),
                    Betimleme = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Öğünler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ÖğünlerÖğeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    ÖğünId = table.Column<int>(nullable: false),
                    Tür = table.Column<int>(nullable: false),
                    ÖğeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÖğünlerÖğeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promosyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promosyonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restoranlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İsim = table.Column<string>(maxLength: 50, nullable: false),
                    ÖzelSektörMü = table.Column<bool>(nullable: false),
                    BankaHesabıIban = table.Column<string>(maxLength: 34, nullable: true),
                    BankaHesabıSahibi = table.Column<string>(maxLength: 100, nullable: true),
                    İletişimId = table.Column<int>(nullable: false),
                    Tür = table.Column<short>(nullable: false),
                    Hizmetler = table.Column<long>(nullable: false),
                    Mutfaklar = table.Column<int>(nullable: false),
                    OnayDurum = table.Column<byte>(nullable: false),
                    ReddetSebebi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoranlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Şehirler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    İngilizceAdı = table.Column<string>(maxLength: 50, nullable: true),
                    ÜlkeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Şehirler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    RestoranId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false),
                    Hazırlanacağı = table.Column<DateTime>(nullable: false),
                    MasaSayısı = table.Column<string>(maxLength: 10, nullable: true),
                    DışMekanSeçimiMi = table.Column<bool>(nullable: true),
                    PaketMi = table.Column<bool>(nullable: false),
                    KuponId = table.Column<int>(nullable: true),
                    PromosyonId = table.Column<int>(nullable: true),
                    Ayrıntılar = table.Column<string>(nullable: true),
                    ToplamFiyat = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SepetlerÖğeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    ÖğeId = table.Column<int>(nullable: false),
                    Tür = table.Column<byte>(nullable: false),
                    Miktar = table.Column<byte>(nullable: false),
                    TekFiyat = table.Column<float>(nullable: false),
                    ToplamFiyat = table.Column<float>(nullable: false),
                    Ayrıntılar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetlerÖğeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparişler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    MüşteriId = table.Column<int>(nullable: false),
                    RestoranId = table.Column<int>(nullable: false),
                    TarihVeZaman = table.Column<DateTime>(nullable: false),
                    GelmeZamanı = table.Column<DateTime>(nullable: true),
                    TeslimTarihVeZaman = table.Column<DateTime>(nullable: true),
                    MasaAdedi = table.Column<byte>(nullable: true),
                    PaketMi = table.Column<bool>(nullable: false),
                    QrKod = table.Column<string>(nullable: true),
                    QrKodResim = table.Column<byte[]>(nullable: true),
                    Ayrıntılar = table.Column<string>(nullable: true),
                    İptalSebebi = table.Column<string>(nullable: true),
                    SepetId = table.Column<int>(nullable: false),
                    Durum = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparişler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiparişlerÖğeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    SiparişId = table.Column<int>(nullable: false),
                    ÖğeId = table.Column<int>(nullable: false),
                    Tür = table.Column<byte>(nullable: false),
                    Miktar = table.Column<byte>(nullable: false),
                    Ayrıntılar = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparişlerÖğeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistemİşlemler",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tip = table.Column<byte>(nullable: false),
                    ÖğeId = table.Column<int>(nullable: false),
                    KullanıcıId = table.Column<int>(nullable: false),
                    Tarih = table.Column<string>(maxLength: 10, nullable: false),
                    Zaman = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistemİşlemler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonNumaralar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İletişimId = table.Column<int>(nullable: false),
                    Kullanım = table.Column<byte>(nullable: false),
                    Numara = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonNumaralar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ülkeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    İngilizceAdı = table.Column<string>(maxLength: 50, nullable: true),
                    BaşkentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ülkeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VarlıklarKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    VarlıkId = table.Column<int>(nullable: false),
                    VarlıkTür = table.Column<byte>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarlıklarKategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yardımİstekler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İstekSahibiId = table.Column<int>(nullable: false),
                    İstekTarihVeZaman = table.Column<DateTime>(nullable: false),
                    Ayrıntılar = table.Column<string>(nullable: true),
                    Durum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yardımİstekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YardımYanıtlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    İstekId = table.Column<int>(nullable: false),
                    İslemTarihVeZaman = table.Column<DateTime>(nullable: false),
                    Yanıt = table.Column<string>(nullable: true),
                    İçNotlar = table.Column<string>(nullable: true),
                    İşlemciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YardımYanıtlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YerlerAdresler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    BinaNumerası = table.Column<string>(maxLength: 7, nullable: true),
                    CaddeSokakAdı = table.Column<string>(maxLength: 25, nullable: true),
                    Enlem = table.Column<float>(nullable: true),
                    Boylam = table.Column<float>(nullable: true),
                    GoogleMapsUrl = table.Column<string>(maxLength: 250, nullable: true),
                    Betimleme = table.Column<string>(maxLength: 150, nullable: true),
                    Notlar = table.Column<string>(maxLength: 25, nullable: true),
                    ÜlkeId = table.Column<int>(nullable: false),
                    ŞehirId = table.Column<int>(nullable: false),
                    İlId = table.Column<int>(nullable: true),
                    İlçeId = table.Column<int>(nullable: true),
                    SemtId = table.Column<int>(nullable: true),
                    MahalleId = table.Column<int>(nullable: true),
                    KöyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YerlerAdresler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semtler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SistemDurum = table.Column<byte>(nullable: false),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    PostaKodu = table.Column<string>(maxLength: 5, nullable: true),
                    İlçeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semtler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semtler_İlçeler_İlçeId",
                        column: x => x.İlçeId,
                        principalTable: "İlçeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semtler_İlçeId",
                table: "Semtler",
                column: "İlçeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BilgiGünlük");

            migrationBuilder.DropTable(
                name: "ÇalışmaZamanlamalar");

            migrationBuilder.DropTable(
                name: "Değerlemeler");

            migrationBuilder.DropTable(
                name: "EpostaAdresler");

            migrationBuilder.DropTable(
                name: "Favoriİçecekler");

            migrationBuilder.DropTable(
                name: "FavoriÖğünler");

            migrationBuilder.DropTable(
                name: "FavoriRestoranlar");

            migrationBuilder.DropTable(
                name: "FavoriYemekler");

            migrationBuilder.DropTable(
                name: "Fotoğraflar");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropTable(
                name: "İletişimler");

            migrationBuilder.DropTable(
                name: "İller");

            migrationBuilder.DropTable(
                name: "İşlemler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "KullanıcılarRestoranlar");

            migrationBuilder.DropTable(
                name: "Kuponlar");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Menüler");

            migrationBuilder.DropTable(
                name: "MenülerÖğeler");

            migrationBuilder.DropTable(
                name: "Müşteriler");

            migrationBuilder.DropTable(
                name: "Öğeler");

            migrationBuilder.DropTable(
                name: "Öğünler");

            migrationBuilder.DropTable(
                name: "ÖğünlerÖğeler");

            migrationBuilder.DropTable(
                name: "Promosyonlar");

            migrationBuilder.DropTable(
                name: "Restoranlar");

            migrationBuilder.DropTable(
                name: "Şehirler");

            migrationBuilder.DropTable(
                name: "Semtler");

            migrationBuilder.DropTable(
                name: "Sepetler");

            migrationBuilder.DropTable(
                name: "SepetlerÖğeler");

            migrationBuilder.DropTable(
                name: "Siparişler");

            migrationBuilder.DropTable(
                name: "SiparişlerÖğeler");

            migrationBuilder.DropTable(
                name: "Sistemİşlemler");

            migrationBuilder.DropTable(
                name: "TelefonNumaralar");

            migrationBuilder.DropTable(
                name: "Ülkeler");

            migrationBuilder.DropTable(
                name: "VarlıklarKategoriler");

            migrationBuilder.DropTable(
                name: "Yardımİstekler");

            migrationBuilder.DropTable(
                name: "YardımYanıtlar");

            migrationBuilder.DropTable(
                name: "YerlerAdresler");

            migrationBuilder.DropTable(
                name: "İlçeler");
        }
    }
}
