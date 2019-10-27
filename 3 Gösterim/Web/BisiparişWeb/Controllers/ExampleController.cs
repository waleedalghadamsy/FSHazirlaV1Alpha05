using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BisiparişWeb.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Working Well");
        }

        [Route("Example/AnotherAction")]
        public IActionResult AnotherAction()
        {
            return Content("Another action is working too");
        }
    }
}