using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppForTest.Controllers
{
    public class TestLabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Route("AnotherOperation")]
        public IActionResult AnotherOperation()
        {
            return Content("Another op is ok");
        }
    }
}