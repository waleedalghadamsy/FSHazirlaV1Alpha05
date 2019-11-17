using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişÇekirdek.Valıklar.VeriGünlüğü;
using BisiparişWeb.Yardımcılar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BisiparişWeb.Pages.SistemGüvenlik
{
    public class GirişModel : PageModel
    {
        //private SignInManager<Kullanıcı> girişYönetim;

        //public GirişModel(SignInManager<Kullanıcı> grşYntm)
        //{
        //    girişYönetim = grşYntm;
        //}

        public string ReturnUrl { get; set; }

        [BindProperty]
        public string Girişİsim { get; set; }
        [BindProperty]
        public string Şifre { get; set; }
        //public Kullanıcı Kullanıcı { get; set; }

        public async Task OnGet(string returnUrl = null)
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                ReturnUrl = returnUrl;
                
                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Into -- Return: {ReturnUrl}");
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
                throw ex;
            }
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                //ReturnUrl = returnUrl;
                //await girişYönetim.SignInAsync(Kullanıcı, false);

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"[1] -- İsim: {Girişİsim} Şifre: {Şifre}");

                //Girişİsim = "Someone"; Şifre = "123";
                var klnc = await GüvenlikYardımcı.Giriş(Girişİsim, Şifre);

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[2]");

                if (klnc == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                //BisiparişWebYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_İşletmeYöneticiMenüKısmiGörüntü";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[3]");

                switch (klnc.Rol)
                {
                    case KullanıcıRol.SistemYönetici:
                        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_SistemYöneticiMenüKısmiGörüntü";
                        break;
                    case KullanıcıRol.İşletmeYönetici:
                        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_İşletmeYöneticiMenüKısmiGörüntü";
                        break;
                    case KullanıcıRol.MüşteriDestekTemsilci:
                        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_DestekTemsilciMenüKısmiGörüntü";
                        break;
                    case KullanıcıRol.İşletmeKullanıcı:
                        GüvenlikYardımcı.ŞuAnkiKullanıcıMenüKısmiGörüntü = "_İşletmeKullanıcıMenüKısmiGörüntü";
                        break;
                }

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[4]");

                

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[5]");

                #region snippet1
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, klnc.Girişİsim),
                    new Claim("FullName", klnc.AdSoyad),
                    new Claim(ClaimTypes.Role, klnc.Rol.ToString()),
                };

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[6]");

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

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[7]");

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                //authProperties);
                #endregion

                //var usr = HttpContext.User != null ? "OK" : "(NULL)";
                //var idnt = (HttpContext.User != null && HttpContext.User.Identity != null) ? "OK" : "(Null)";
                //var isathn = (HttpContext.User != null && HttpContext.User.Identity != null)
                //    ? HttpContext.User.Identity.IsAuthenticated : false;

                //var isSessionAvailable = HttpContext.Session != null ? "OK" : "(NULL)";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, 
                //    $"[4] -- CtxtUsr: {usr} | Ident: {idnt} | IsAuth: {isathn}");

                //var ctxt = HttpContext != null ? "OK" : "(NULL)";
                //var sson = (HttpContext != null && HttpContext.Session != null) ? "OK" : "(NULL)";

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Context: {ctxt} | Session: {sson}");

                BisiparişWebYardımcı.Session = HttpContext.Session;

                await GüvenlikYardımcı.KullanıcıGirişti(klnc);

                //klnc.Rol = KullanıcıRol.İşletmeYönetici;

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "Storing user in Session...");

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "User stored in Session");

                //_logger.LogInformation("User {Email} logged in at {Time}.",
                //    user.Email, DateTime.UtcNow);

                //var rtrn = Url.GetLocalUrl(returnUrl);

                //await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, "[8]");// -- Returning to: {rtrn}");

                var respHdrs = HttpContext.Response.Headers;
                foreach (var hdrKey in respHdrs.Keys)
                        await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Ayıklama, $"Resp header: {hdrKey}: {respHdrs[hdrKey]}");

                return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }
            catch (Exception ex)
            {
                await BisiparişWebYardımcı.GünlükKaydetme(OlaySeviye.Hata, ex.Message);
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