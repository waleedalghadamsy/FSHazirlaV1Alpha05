using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BisiparişWeb.Modeller.Restoranlar
{
    public class RestoranGörünümModel : Restoran
    {
        public RestoranGörünümModel(Restoran rst)
        {
            Id = rst.Id; İsim = rst.İsim; Tür = rst.Tür; İletişimId = rst.İletişimId;

            RestoranTürler = new Dictionary<RestoranTür, string>()
            {
                { RestoranTür.CafeVeİçecek, "Cafe ve İçecek" },
                { RestoranTür.Kahvaltı, "Kahvaltı" },
                { RestoranTür.Lokanta, "Lokanta" },
                { RestoranTür.LüksYemek, "Lüks Yemek" },
                { RestoranTür.Pastaneler, "Pastaneler" },
                { RestoranTür.RomantikMekanlar, "Romantik Mekanlar" },
                { RestoranTür.SokakLezzetleri, "Sokak Lezzetleri" },
                { RestoranTür.Yemek, "Yemek" },
                { RestoranTür.YeVeKalk, "Ye ve Kalk" },
                { RestoranTür.Tatlıcı, "Tatlıcı" },
            };
        }

        private static Dictionary<RestoranTür, string> RestoranTürler { get; set; }
        public string DizTür { get; set; }
        public string İlAd { get; set; }
        public string İlçeAd { get; set; }
        public string SemtAd { get; set; }
        public string MahalleAd { get; set; }
        public byte[] Fotoğraf { get; set; }
        public string ResimKaynak { get; set; }

        public async Task VerilerDoldur()
        {
            try
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Into Restaurant Veri Doldur...");

                DizTür = RestoranTürler[Tür];

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant comm...");

                İletişim = await BisiparişWebYardımcı.İşyeriİletişimAl(İletişimId);

                //İlAd = İletişim.Adres; İlAd = İletişim.Adres.İlId;

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant photos...");

                var fotolr = await BisiparişWebYardımcı.RestoranFotoğraflarAl(Id);

                if (fotolr != null && fotolr.Any())
                {
                    Fotoğraflar = fotolr.Select(f => f.Fotoğraf).ToList();

                    Fotoğraf = Fotoğraflar.First();

                    await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Converting restaurant photo...");

                    ResimKaynak = $"data:image/png;base64,{Convert.ToBase64String(Fotoğraf)}";
                }

                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Got all requirements");

                //Menüler
                //ÇalışmaZamanlamalar
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, $"Restaurant Veri Doldur Exp: {ex.Message}");
                throw ex;
            }
        }
    }
}
