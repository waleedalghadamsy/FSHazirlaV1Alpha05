using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ExampleDataLibrary.Migrations
{
    public partial class ExampleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ÇalışmaZamanlamalar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "Kullanıcılar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Oluşturulduğunda = table.Column<DateTime>(nullable: false),
                    OluşturuKimsiId = table.Column<int>(nullable: false),
                    AdSoyad = table.Column<string>(maxLength: 100, nullable: false),
                    Pozisyon = table.Column<string>(maxLength: 50, nullable: true),
                    Girişİsim = table.Column<string>(maxLength: 30, nullable: false),
                    AsılŞifre = table.Column<string>(nullable: true),
                    KarmaŞifre = table.Column<string>(nullable: false),
                    EPostaAdres = table.Column<string>(maxLength: 50, nullable: false),
                    MobilNumara = table.Column<string>(maxLength: 30, nullable: false),
                    KaldırmaSebebi = table.Column<string>(nullable: true),
                    SonGirişTarihVeZaman = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YerAdresler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    table.PrimaryKey("PK_YerAdresler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ÇalışmaZamanlamalar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "YerAdresler");
        }
    }
}
