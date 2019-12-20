﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
using HazırlaWebArkaUç.Modeller.Restoranlar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HazırlaWebArkaUç.Pages.Restoranlar
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<RestoranGörünümModel> Restoranlar { get; set; }

        public async Task OnGet()
        {
            try
            {
                var rstrnlr = await Yardımcılar.RestoranlarYardımcı.RestoranlarAl();

                if (rstrnlr != null && rstrnlr.Any())
                {
                    Restoranlar = new List<RestoranGörünümModel>();

                    foreach (var rst in rstrnlr)
                    {
                        var rstgm = new RestoranGörünümModel(rst);

                        await rstgm.VerilerDoldur();

                        Restoranlar.Add(rstgm);
                    }
                }
            }
            catch (Exception ex)
            {
                await HazırlaWebYardımcı.HataKaydet(ex);
                throw ex;
            }
        }
    }
}