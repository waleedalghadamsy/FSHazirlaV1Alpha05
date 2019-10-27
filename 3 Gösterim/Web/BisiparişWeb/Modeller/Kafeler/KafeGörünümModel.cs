using BisiparişÇekirdek.Valıklar.Erzak;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BisiparişWeb.Modeller.Kafeler
{
    public class KafeGörünümModel : Kafe
    {
        public KafeGörünümModel(Kafe kafe)
        {
            Id = kafe.Id; İsim = kafe.İsim; İletişimId = kafe.İletişimId;
        }

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
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Into Kafe Veri Doldur...");

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting kafe comm...");

                İletişim = await BisiparişWebYardımcı.İşyeriİletişimAl(İletişimId);

                //İlAd = İletişim.Adres; İlAd = İletişim.Adres.İlId;

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting kafe photos...");

                var fotolr = await BisiparişWebYardımcı.KafeFotoğraflarAl(Id);

                if (fotolr != null && fotolr.Any())
                {
                    Fotoğraflar = fotolr.Select(f => f.Fotoğraf).ToList();

                    Fotoğraf = Fotoğraflar.First();

                    //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Converting restaurant photo...");

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
