using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YeniKullanıcıModel : PageModel
    {
        [BindProperty]
        public string KökDizin { get; set; }
        [BindProperty]
        public Kullanıcı Kullanıcı { get; set; }
        [BindProperty]
        public List<SelectListItem> KullanıcıRolar { get; set; }
        [BindProperty]
        public string RolSeçildi { get; set; }
        [BindProperty]
        public string KaydetmekSonuç { get; set; }

        public void OnGet()
        {
            try
            {
                KökDizin = BisiparişWebYardımcı.KökDizin;

                Kullanıcı = new Kullanıcı();

                KullanıcıRolar = BisiparişWebYardımcı.KullanıcıRolar;

                KaydetmekSonuç = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task OnPost()
        {
            try
            {
                Kullanıcı.Rol = (KullanıcıRol)Enum.Parse(typeof(KullanıcıRol), RolSeçildi);

                var sonuç = await BisiparişWebYardımcı.YeniKullanıcıEkle(Kullanıcı);

                KaydetmekSonuç = BisiparişWebYardımcı.OpSonuçMesajAl(İcraOperasyon.Kaydetmek, sonuç);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}