using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class TestOperationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnotherOperation()
        {
            return Content("Another op is ok");
        }
    }
}