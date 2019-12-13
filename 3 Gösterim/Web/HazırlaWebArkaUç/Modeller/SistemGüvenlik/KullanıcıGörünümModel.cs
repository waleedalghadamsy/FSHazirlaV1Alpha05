using HazırlaÇekirdek.Valıklar.Güvenlik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazırlaWebArkaUç.Modeller.SistemGüvenlik
{
    public class KullanıcıGörünümModel : Kullanıcı
    {
        private Dictionary<KullanıcıRol, string> Rolİsim = new Dictionary<KullanıcıRol, string>()
        {
            { KullanıcıRol.SistemYönetici, "Sistem Yönetici" },
            { KullanıcıRol.MüşteriDestekTemsilci, "Müşteri Temsilci" },
            { KullanıcıRol.İşletmeYönetici, "İşletme Yönetici" },
            { KullanıcıRol.İşletmeKullanıcı, "İşletme Çalışan" },
            { KullanıcıRol.Müşteri, "Müşteri" }
        };

        public KullanıcıGörünümModel(Kullanıcı klnc)
        {
            Id = klnc.Id; 
            AdSoyad = klnc.AdSoyad; Pozisyon = klnc.Pozisyon; Rol = klnc.Rol; Girişİsim = klnc.Girişİsim;
            DizRol = Rolİsim[Rol]; DizCinsiyet = klnc.Cinsiyet.ToString();
            SistemDurum = klnc.SistemDurum; SonGirişTarihVeZaman = klnc.SonGirişTarihVeZaman;
            DizSonGiriş = SonGirişTarihVeZaman.HasValue ? SonGirişTarihVeZaman.Value.ToString("dd-MM-yyyy HH:mm:ss") : "";
        }

        public string DizCinsiyet { get; set; }
        public string DizRol { get; set; }
        public string DizSonGiriş { get; set; }
    }
}
