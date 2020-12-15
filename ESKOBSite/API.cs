using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ESKOBSite
{
    public class API
    {
        private static readonly Uri uri = new Uri("https://localhost:44377/"); 

        public static async Task<HttpResponseMessage> GET(string url)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetAsync(url).Result;
            }
        }

        public static async Task<bool> VALIDATETENANT(string tenant)
        {
            if (tenant.Equals("")) return false;

            var response = GET("/tenants/" + tenant).Result;
            if ((int) response.StatusCode == 200)
            {
                return true;
            }

            return false;
        }
    }
}