using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HazırlaWebArkaUç.Pages.Bildirimler
{
    public class GönderModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
			try
			{
                await Task.Run(() => { });

                if (HttpContext.Session != null)
                {
                    return Page();
                }
                else
                    return LocalRedirect(Uri.EscapeUriString("/SistemGüvenlik/Giriş?ReturnUrl=/"));
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}