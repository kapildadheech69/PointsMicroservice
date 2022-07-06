using System;
using System.Net.Http;

namespace PointsMicroservice.Models
{
    public class Helper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://offermfpe.azurewebsites.net/");
            return client;
        }
    }
}
