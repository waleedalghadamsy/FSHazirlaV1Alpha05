using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.Güvenlik;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HazırlaWebArkaUç.Pages.SistemGüvenlik
{
    public class GirişModel : PageModel
    {
        //private SignInManager<Kullanıcı> girişYönetim;

        public GirişModel(IHttpContextAccessor contextAccessor)
        {
            HazırlaWebYardımcı.HttpContextAccessor = contextAccessor;
        }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public string Girişİsim { get; set; }
        [BindProperty]
        public string Şifre { get; set; }
        //public Kullanıcı Kullanıcı { get; set; }

        public async Task OnGetAsync()//string returnUrl = null)
        {
            try
            {
                await HazırlaWebYardımcı.AyıklamaKaydet("Into...");

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                //ReturnUrl = returnUrl;
                
                //await HazırlaWebYardımcı.AyıklamaKaydet("Signed out. Now opening page...");
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> OnPostAsync()//string returnUrl = null)
        {
            try
            {
                //ReturnUrl = returnUrl;
                //await girişYönetim.SignInAsync(Kullanıcı, false);

                //await HazırlaWebYardımcı.AyıklamaKaydet($"[1] -- İsim: {Girişİsim} Şifre: {Şifre}");

                //Girişİsim = "Someone"; Şifre = "123";
                var klnc = await GüvenlikYardımcı.Giriş(Girişİsim, Şifre);

                //await HazırlaWebYardımcı.AyıklamaKaydet("[2]");

                if (klnc == null)
                {
                    //TODO: Show error message
                    //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                //switch (klnc.Rol)
                //{
                //    case KullanıcıRol.SistemYönetici:
                //        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_SistemYöneticiMenüKısmiGörüntü";
                //        break;
                //    case KullanıcıRol.İşletmeYönetici:
                //        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_İşletmeYöneticiMenüKısmiGörüntü";
                //        break;
                //    case KullanıcıRol.MüşteriDestekTemsilci:
                //        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_DestekTemsilciMenüKısmiGörüntü";
                //        break;
                //    case KullanıcıRol.İşletmeKullanıcı:
                //        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_İşletmeKullanıcıMenüKısmiGörüntü";
                //        break;
                //}

                //await HazırlaWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[4]");



                //await HazırlaWebYardımcı.AyıklamaKaydet("[5]");

                #region snippet1
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, klnc.Girişİsim),
                    new Claim("FullName", klnc.AdSoyad),
                    new Claim(ClaimTypes.Role, klnc.Rol.ToString()),
                };

                //await HazırlaWebYardımcı.AyıklamaKaydet("[6]");

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HazırlaWebYardımcı.AyıklamaKaydet("[7]");

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                //authProperties);
                #endregion

                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";
                //await HazırlaWebYardımcı.AyıklamaKaydet($"[8] -- Session: {isSessionAvailable}");

                if (HazırlaWebYardımcı.Session == null)
                    HazırlaWebYardımcı.Session = HttpContext.Session;

                //await HazırlaWebYardımcı.AyıklamaKaydet("[9]");

                await GüvenlikYardımcı.KullanıcıGirişti(klnc);

                //GüvenlikYardımcı.KullanıcıMenüAyarla();

                //await HazırlaWebYardımcı.AyıklamaKaydet("[10]");

                return LocalRedirect("/");// Url.GetLocalUrl(returnUrl));
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }

    public static class UrlHelperExtensions
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/Index");
            }

            return localUrl;
        }
    }
}