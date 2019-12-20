using HazırlaÇekirdek.Valıklar.Erzak;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Yardımcılar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HazırlaWebArkaUç.Modeller.Restoranlar
{
    public class RestoranGörünümModel : Restoran
    {
        public RestoranGörünümModel(Restoran rst)
        {
            Id = rst.Id; İsim = rst.İsim; Tür = rst.Tür; İletişimId = rst.İletişimId;

            RestoranTürler = new Dictionary<RestoranTürler, string>()
            {
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.CafeVeİçecek, "Cafe ve İçecek" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.Kahvaltı, "Kahvaltı" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.Lokanta, "Lokanta" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.LüksYemek, "Lüks Yemek" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.Pastaneler, "Pastaneler" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.RomantikMekanlar, "Romantik Mekanlar" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.SokakLezzetleri, "Sokak Lezzetleri" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.Yemek, "Yemek" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.YeVeKalk, "Ye ve Kalk" },
                { HazırlaÇekirdek.Valıklar.Erzak.RestoranTürler.Tatlıcı, "Tatlıcı" },
            };
        }

        private static Dictionary<RestoranTürler, string> RestoranTürler { get; set; }
        public string DizTür { get; set; }
        public string DizHizmetler { get; set; }
        public string DizMutfaklar { get; set; }
        public string İlAd { get; set; }
        public string İlçeAd { get; set; }
        public string SemtAd { get; set; }
        public string MahalleAd { get; set; }
        public byte[] Fotoğraf { get; set; }
        public string ResimKaynak { get; set; }
        public string MenüSayısı { get; set; }

        public async Task VerilerDoldur()
        {
            try
            {
                var dizHizmetlerSB = new StringBuilder(""); var dizMutfaklarSB = new StringBuilder("");

                //await HazırlaWebYardımcı.AyıklamaKaydet("Into Restaurant Veri Doldur...");

                DizTür = RestoranTürler[Tür];

                if (Hizmetler != RestoranHizmetler.Hiçbiri)
                {
                    foreach (var birHizmet in Enum.GetValues(typeof(RestoranHizmetler)))
                    {
                        var enmHizmet = (RestoranHizmetler)Enum.Parse(typeof(RestoranHizmetler), birHizmet.ToString());

                        if ((Hizmetler & enmHizmet) == enmHizmet)
                            dizHizmetlerSB.Append($"{RestoranlarYardımcı.RestoranHizmetleri[enmHizmet]} |");
                    }

                    //TODO: Remove the last extra separator
                }

                DizHizmetler = dizHizmetlerSB.ToString();

                if (Mutfaklar != Mutfaklar.Hiçbiri)
                {
                    foreach (var birMtfk in Enum.GetValues(typeof(Mutfaklar)))
                    {
                        var enmMtfk = (Mutfaklar)Enum.Parse(typeof(Mutfaklar), birMtfk.ToString());

                        if ((Mutfaklar & enmMtfk) == enmMtfk)
                            dizMutfaklarSB.Append($"{RestoranlarYardımcı.RestoranMutfakları[enmMtfk]} |");
                    }

                    //TODO: Remove the last extra separator
                }

                DizMutfaklar = dizMutfaklarSB.ToString();

                var rstrnMnlr = await Yardımcılar.MenülerYardımcı.RestoranMenülerAl(Id);
                MenüSayısı = rstrnMnlr != null && rstrnMnlr.Any() ? rstrnMnlr.Count.ToString() : "0";

                await HazırlaWebYardımcı.AyıklamaKaydet($"Hizmetler: {Hizmetler} -- Diz: {DizHizmetler}");

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant comm...");

                İletişim = await HazırlaWebYardımcı.İşyeriİletişimAl(İletişimId);

                //İlAd = İletişim.Adres; İlAd = İletişim.Adres.İlId;

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Getting restaurant photos...");

                var fotolr = await Yardımcılar.RestoranlarYardımcı.RestoranFotoğraflarAl(Id);

                if (fotolr != null && fotolr.Any())
                {
                    Fotoğraflar = fotolr.Select(f => f.Fotoğraf).ToList();

                    Fotoğraf = Fotoğraflar.First();

                    //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Converting restaurant photo...");

                    ResimKaynak = $"data:image/png;base64,{Convert.ToBase64String(Fotoğraf)}";
                }

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Uyarı, "Got all requirements");

                //Menüler
                //ÇalışmaZamanlamalar
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}
