using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiExample
{
    public class ExampleApiHelper
    {
        public static IMemoryCache Cache { get; set; }
    }
}
