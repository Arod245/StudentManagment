using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentMVC
{
    public class APIHelper
    {
        public static HttpClient client { get; set; }

        static APIHelper()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44350/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}
