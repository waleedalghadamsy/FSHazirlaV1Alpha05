using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        public string Get(string name)
        {
            try
            {
                return $"{ExampleApiHelper.Cache.Get("Greeting").ToString()} {name}";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            
        }
    }
}