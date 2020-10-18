using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MovieTicketBooking.Helper
{
    public class UserAPI
    {
        public HttpClient Initaluser()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44374/");
            return client;
        }
        public HttpClient Initalmovie()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/");
            return client;
        }
        public HttpClient Initaladmin()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44376/");
            return client;
        }
        public HttpClient Initalauthorization()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44320/");
            return client;
        }
        public HttpClient Initalbookingt()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44332/");
            return client;
        }
    }
}
