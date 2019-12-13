using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppOnLinux.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Kullanıcı> Kullanıcılar { get; set; }
        [BindProperty]
        public string ResultMessage { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ResultMessage = "";
        }

        public ActionResult OnPost()
        {
            StringBuilder resultSB = new StringBuilder();

            try
            {
                ResultMessage = "";

                resultSB.Append("Into Post <br/>");

                using (var dbCtx = new ExampleDbContext() { ConnectionString = "User ID = waleedpg; Password = AbcXyz123; Server = localhost; Port = 5432; Database = turkexample2; " })
                //    + "Integrated Security = true; Pooling = true;""))
                {
                    resultSB.Append("Into using <br/>");

                    var klnclr = dbCtx.Kullanıcılar;

                    if (klnclr != null && klnclr.Any())
                    {
                        resultSB.Append("Got users <br/>");

                        Kullanıcılar = klnclr.ToList();
                    }
                    else
                        resultSB.Append("There are no users!! <br/>");

                    //var prsns = dbCtx.persons;

                    //if (prsns != null && prsns.Any())
                    //{
                    //    foreach (var p in prsns)
                    //        personsListBox.Items.Add($"{p.name} {p.birthdate.ToString("yyyy-MM-dd")} {p.email}");
                    //}
                }

                resultSB.Append("Out of Post <br/>");

                ResultMessage = resultSB.ToString();

                return Page();
            }
            catch (Exception ex)
            {
                resultSB.Append(ex.ToString());

                ResultMessage = resultSB.ToString();

                return Page();
            }
        }
    }
}
