using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralWebApp
{
    public class WebAppHelper
    {
        //public WebAppHelper(ExmplApiClient apiClient)
        //{
        //    ExmplClient = apiClient;
        //}

        public static IMemoryCache Cache { get; set; }
        public static ExmplApiClient ExmplClient { get; set; }
    }
}
