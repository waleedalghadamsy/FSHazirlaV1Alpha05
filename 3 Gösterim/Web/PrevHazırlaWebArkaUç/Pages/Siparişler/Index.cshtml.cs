﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HazırlaWebArkaUç.Pages.Siparişler
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int TotalPages { get; set; }

        [BindProperty]
        public int CurrentPage { get; set; }

        public void OnGet()
        {

        }
    }
}