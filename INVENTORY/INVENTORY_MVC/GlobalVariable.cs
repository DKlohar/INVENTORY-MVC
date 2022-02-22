using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace INVENTORY_MVC
{
    public static class GlobalVariable
    {
        public static HttpClient WebApliClient = new HttpClient();

        static GlobalVariable()
        {
            WebApliClient.BaseAddress = new Uri("https://localhost:44325/api/");
            WebApliClient.DefaultRequestHeaders.Clear();
            WebApliClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}